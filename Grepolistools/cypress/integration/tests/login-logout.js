describe('Login Page', () => {
  beforeEach(() => {
  });

  it('login page', () => {
    cy.visit('localhost:4200/login');
    cy.get('[data-cy=login-username]').type('web4');
    cy.get('[data-cy=login-password]').type('gelukkiggeennetbeans');
    cy.get('[data-cy=login-button').click();
    // login name should be in the title balk
    cy.contains('web4');
    // at last one recipe should be visible (i.e. we should have been forwarded to the recipe page)
    cy.get('[data-cy=logout]').should('be.visible');
  });

  it('logout page', () => {
    cy.get('[data-cy=logout]').should('be.visible');

    cy.get('[data-cy=logout]').click();

    cy.get('[data-cy="login"]').should('be.visible');

  });
});


