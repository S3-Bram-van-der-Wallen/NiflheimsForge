import React, { useState } from "react";
import Constants from "./utilities/Constants";
import CountryCreateForm from "./components/CountryCreateForm";
import CountryUpdateForm from "./components/CountryUpdateForm";

export default function App() {
  const [countries, setCountries] = useState([]);
  const [showingCreateNewCountryForm, setShowingCreateNewCountryForm] = useState(false);
  const [countryCurrentlyBeingUpdated, setCountryCurrentlyBeingUpdated] = useState(null);

  function getCountries() {
    const url = Constants.API_URL_GET_ALL_COUNTRIES;

    fetch(url, {
      method: 'GET'
    })
      .then(response => response.json())
      .then(countriesFromServer => {
        setCountries(countriesFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  }

  function deleteCountry(id) {
    const url = Constants.API_URL_DELETE_COUNTRY_BY_ID;

    fetch(`${url}/${id}`, {
      method: 'DELETE'
    })
      .then(response => response.json())
      .then(responseFromServer => {
        console.log(responseFromServer);
        onCountryDeleted(id);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  }

  return (
    <div className="container">
      <div className="row min-vh-100">
        <div className="col d-flex flex-column justify-content-center align-items-center">
          {(showingCreateNewCountryForm === false && countryCurrentlyBeingUpdated === null) && (
            <div>
              <h1>Countries</h1>

              <div className="mt-5">
                <button onClick={getCountries} className="btn btn-dark btn-lg w-100">Get Countries from server</button>
                <button onClick={() => setShowingCreateNewCountryForm(true)} className="btn btn-secondary btn-lg w-100 mt-4">Create new Country</button>
              </div>
            </div>
          )}

          {(countries.length > 0 && showingCreateNewCountryForm === false && countryCurrentlyBeingUpdated === null) && renderCountriesTable()}

          {showingCreateNewCountryForm && <CountryCreateForm onCountryCreated={onCountryCreated} />}

          {countryCurrentlyBeingUpdated !== null && <CountryUpdateForm country={countryCurrentlyBeingUpdated} onCountryUpdated={onCountryUpdated} />}
        </div>
      </div>
    </div>
  );

  function renderCountriesTable() {
    return (
      <div className="table-responsive mt-5">
        <table className="table table-bordered border-dark">
          <thead>
            <tr>
              <th scope="col">CountryId (PK)</th>
              <th scope="col">Name</th>
              <th scope="col">Description</th>
              <th scope="col">CRUD Operations</th>
            </tr>
          </thead>
          <tbody>
            {countries.map((country) => (
              <tr key={country.id}>
                <th scope="row">{country.id}</th>
                <td>{country.name}</td>
                <td>{country.description}</td>
                <td>
                  <button onClick={() => setCountryCurrentlyBeingUpdated(country)}className="btn btn-dark btn-lg mx-3 my-3">Update</button>
                  <button onClick={() => { if(window.confirm(`Are you sure you want to delete "${country.name}"?`)) deleteCountry(country.id) }} className="btn btn-secondary btn-lg">Delete</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
        <button onClick={() => setCountries([])} className="btn btn-dark btn-lg w-100">Empty Countries Array</button>
      </div>
    );
  }

  function onCountryCreated(createdCountry) {
    setShowingCreateNewCountryForm(false);

    if (createdCountry === null) {
      return;
    }

    alert(`Crountry successfully created. After clicking OK, your new post tilted "${createdCountry.name} will show up in the table below."`);

    getCountries();
  }
  
  function onCountryUpdated(updatedCountry){
    setCountryCurrentlyBeingUpdated(null);

    if (updatedCountry === null){
      return;
    }

    let countriesCopy = [...countries];

    const index = countriesCopy.findIndex((countriesCopyCountry, currentIndex) => {
      if (countriesCopyCountry.countryId === updatedCountry.countryId){
        return true;
      }
    });

    if (index !== -1){
      countriesCopy[index] = updatedCountry;
    }

    setCountries(countriesCopy);

    alert(`Country successfully updated. After clicking OK, look for the post with the title "${updatedCountry.name}" in the table below to see updates.`)
  }

  function onCountryDeleted(deletedCountryId){
    let countriesCopy = [...countries];

    const index = countriesCopy.findIndex((countriesCopyCountry, currentIndex) => {
      if (countriesCopyCountry.id === deletedCountryId){
        return true;
      }
    });

    if (index !== -1){
      countriesCopy.splice(index, 1);
    }

    setCountries(countriesCopy);

    alert('Country successfully deleted, after clicking OK, look at the table below to see the post disapear')
  }
}
