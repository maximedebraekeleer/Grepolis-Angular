describe('Error 404 on wrong paramaters', () => {
  beforeEach(() => {
  });

  it('player page', () => {
    //WERKENDE SPELER MET USERNAME 'THE EXALTED ONE'
    cy.visit('http://localhost:4200/player/nl/64/1167116');

    cy.get('[data-cy=player]').should('be.visible');
    cy.contains('The Exalted One');

    //ONGELDIGE PARAMETER WERELD 500 BESTAAT NIET
    cy.visit('http://localhost:4200/player/nl/500/1167116')
    cy.get('[data-cy=404]').should('be.visible');
  });

  it('server page', () => {
    //WERKENDE SERVER 'NL'
    cy.visit('http://localhost:4200/server/nl/');

    cy.get('[data-cy=server]').should('be.visible');

    //ONGELDIGE PARAMETER SERVER 'rusland' BESTAAT NIET
    cy.visit('http://localhost:4200/server/rusland')
    cy.get('[data-cy=404]').should('be.visible');
  });

  it('search page', () => {
    //WERKENDE ZOEKOPDRACHT NAAR SPELER 'THE EXALTED ONE'
    cy.visit('http://localhost:4200/search/The%20Exalted%20One');

    cy.get('[data-cy=search]').should('be.visible');

    //ONGELDIGE PARAMETER ZOEKOPDRACHT '12365' BESTAAT NIET
    cy.visit('http://localhost:4200/search/12365')
    cy.get('[data-cy=playernotFound]').should('be.visible');
  });
});
