import React, { useState } from 'react';
import Constants from '../utilities/Constants';

export default function CountryUpdateForm(props) {
    const initialFormData = Object.freeze({
        name: props.country.name,
        description: props.country.description
    });

    const [formData, setFormData] = useState(initialFormData);

    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value
        });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        console.log(props.country.id);
        const countryToUpdate = {
            id: props.country.id,
            name: formData.name,
            description: formData.description
        };
    
        const url = Constants.API_URL_UPDATE_COUNTRY;
        console.log(url);
        fetch(`${url}/${countryToUpdate.id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(countryToUpdate)
        })
            .then(response => response.json())
            .then(responseFromServer => {
                console.log(responseFromServer);
            })
            .catch((error) => {
                console.log(error);
                alert(error);
            });
    
        props.onCountryUpdated(countryToUpdate);
    };

    return (
        <form className="w-100 px-5">
            <h1 className="mt-5">Update "{props.country.name}"</h1>

            <div className='Mt-5'>
                <label className='h3 form-label'>Country name</label>
                <input value={formData.name} name='name' type='text' className='form-control' onChange={handleChange} />
            </div>

            <div className='Mt-4'>
                <label className='h3 form-label'>Country description</label>
                <input value={formData.description} name='description' type='text' className='form-control' onChange={handleChange} />
            </div>

            <button onClick={handleSubmit} className='btn btn-dark btn-lg w-100 mt-5'>Submit</button>
            <button onClick={() => props.onCountryUpdated(null)} className='btn btn-secondary btn-lg w-100 mt-3'>Cancel</button>
        </form>
    );
}
