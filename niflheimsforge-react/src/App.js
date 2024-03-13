import React, { useState } from "react";
import Constants from "./utilities/Constants";

export default function App() {
  const [countries, setCountries] = useState([]);

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

  return (
    <div className="container">
      <div className="row min-vh-100">
        <div className="col d-flex flex-column justify-content-center align-items-center">
          <div>
            <h1>Countries</h1>

            <div className="mt-5">
              <button onClick={getCountries} className="btn btn-dark btn-lg w-100">Get Countries from server</button>
              <button onClick={() => { }} className="btn btn-secondary btn-lg w-100 mt-4">Create new Country</button>
            </div>
          </div>

          {countries.length > 0 && renderCountriesTable()}
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
                  <button className="btn btn-dark btn-lg mx-3 my-3">Update</button>
                  <button className="btn btn-secondary btn-lg">Delete</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
        <button onClick={() => setCountries([])} className="btn btn-dark btn-lg w-100">Empty Countries Array</button>
      </div>
    )
  }
}
