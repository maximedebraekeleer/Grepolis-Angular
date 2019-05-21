import {Component, OnInit} from '@angular/core';
import {AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators} from '@angular/forms';
import {Router} from '@angular/router';
import {AuthenticationService} from '../authentication.service';
import {Observable} from 'rxjs';
import {map} from 'rxjs/operators';
import {HttpErrorResponse} from '@angular/common/http';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit
{
  public user: FormGroup;
  public errorMsg : String;

  constructor(    private authService: AuthenticationService,
                  private router: Router,
                  private fb: FormBuilder){}

  ngOnInit() {
    this.user = this.fb.group({
      username: ['', Validators.required, serverSideValidateUsername(this.authService.checkUserNameAvailability)],
      email: [
        '',
        [Validators.required, Validators.email,],
        serverSideValidateEmail(this.authService.checkEmailAvailability)
      ],
      passwordGroup: this.fb.group(
        {
          password: ['', [Validators.required, Validators.minLength(8)]],
          confirmPassword: ['', Validators.required]
        },
        { validator: comparePasswords }
      )
    });
  }

  onSubmit() {
    this.authService
      .register(
        this.user.value.username,
        this.user.value.email,
        this.user.value.passwordGroup.password
      )
      .subscribe(
        val => {
          if (val) {
            if (this.authService.redirectUrl) {
              this.router.navigateByUrl(this.authService.redirectUrl);
              this.authService.redirectUrl = undefined;
            } else {
              this.router.navigate(['']);
            }
          } else {
            this.errorMsg = `Could not login`;
          }
        },
        (err: HttpErrorResponse) => {
          console.log(err);
          if (err.error instanceof Error) {
            this.errorMsg = `Error while trying to login user ${
              this.user.value.email
              }: ${err.error.message}`;
          } else {
            this.errorMsg = `Error ${err.status} while trying to login user ${
              this.user.value.email
              }: ${err.error}`;
          }
        }
      );
  }

  getErrorMessage(errors: any) {
    if (!errors) {
      return null;
    }
    if (errors.required) {
      return 'is required';
    } else if (errors.minlength) {
      return `needs at least ${
        errors.minlength.requiredLength
        } characters (got ${errors.minlength.actualLength})`;
    } else if (errors.userAlreadyExists) {
      return `user already exists`;
    } else if (errors.email) {
      return `not a valid email address`;
    } else if (errors.passwordsDiffer) {
      return `passwords are not the same`;
    } else if (errors.emailAlreadyExists) {
      return `email already exists`;
    }
  }

}

function comparePasswords(control: AbstractControl): { [key: string]: any }
{
  const password = control.get('password');
  const confirmPassword = control.get('confirmPassword');
  return password.value === confirmPassword.value
    ? null
    : { passwordsDiffer: true };
}

function serverSideValidateUsername(
  checkAvailabilityFn: (n: string) => Observable<boolean>
): ValidatorFn {
  return (control: AbstractControl): Observable<{ [key: string]: any }> => {
    return checkAvailabilityFn(control.value).pipe(
      map(available => {
        if (available) {
          return null;
        }
        return { userAlreadyExists: true };
      })
    );
  };
}

function serverSideValidateEmail(
  checkAvailabilityFn: (n: string) => Observable<boolean>
  ) : ValidatorFn {
  return (control: AbstractControl): Observable<{ [key: string]: any }> => {
    return checkAvailabilityFn(control.value).pipe(
      map(available => {
        if (available) {
          return null;
        }
        return { emailAlreadyExists: true };
      })
    );
  };
}
