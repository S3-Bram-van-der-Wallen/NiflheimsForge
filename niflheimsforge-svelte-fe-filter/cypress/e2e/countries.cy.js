it('should retrieve more than 1 country from the db', () => {
    cy.visit('/countries')
    cy.get('.list-group')
      .should('have.length.greaterThan', 1);
});

it('should fetch and display the selected country details', () => {
    cy.visit('/countries')
    cy.get('.list-group')
      .find('.list-group-item-action')
      .first()
      .click();

    cy.get('.country-details h1').should('not.be.empty');
    cy.get('.country-details p').should('not.be.empty');
});