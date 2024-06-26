import React, { useState } from 'react';
import Constants from '../utilities/Constants';

export default function CountryCreateForm(props) {
    const initialFormData = Object.freeze({
        name: "Country A",
        description: "This is country A and it has some interesting cities"
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

        const countryToCreate = {
            countryId: '79f4f016-c954-47dd-a082-f2838b7326dd',
            name: formData.name,
            description: formData.description
        };

        const url = Constants.API_URL_CREATE_COUNTRY;
        console.log(countryToCreate);
        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(countryToCreate)
        })
            .then(response => response.json())
            .then(responseFromServer => {
                console.log(responseFromServer);
            })
            .catch((error) => {
                console.log(error);
                alert(error);
            });

        props.onCountryCreated(countryToCreate);
    };

    return (
        <form className="w-100 px-5">
            <h1 className="mt-5">Create a new country</h1>

            <div className='Mt-5'>
                <label className='h3 form-label'>Country name</label>
                <input value={formData.name} name='name' type='text' className='form-control' onChange={handleChange} />
            </div>

            <div className='Mt-4'>
                <label className='h3 form-label'>Country description</label>
                <input value={formData.description} name='description' type='text' className='form-control' onChange={handleChange} />
            </div>

            <button onClick={handleSubmit} className='btn btn-dark btn-lg w-100 mt-5'>Submit</button>
            <button onClick={() => props.onCountryCreated(null)} className='btn btn-secondary btn-lg w-100 mt-3'>Cancel</button>
        </form>
    );
}
