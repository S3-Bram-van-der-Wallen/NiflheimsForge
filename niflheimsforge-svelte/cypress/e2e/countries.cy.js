it('should retrieve more than 1 country from the db', () => {
  cy.visit('/countries');
  cy.get('.list-group-item-action').should('have.length.greaterThan', 2);
});

it('should fetch and display the selected country details', () => {
  cy.visit('/countries');
  cy.get('.list-group')
    .find('.list-group-item-action')
    .first()
    .click();

  cy.get('.country-details h1', { timeout: 10000 }).should($h1 => {
    expect($h1.text().trim()).not.to.equal('please choose a country');
  });
  cy.get('.country-details p').should('not.be.empty');
});
