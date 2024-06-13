import { json } from '@sveltejs/kit';

export async function GET({ params }) {
    const response = await fetch(`http://localhost:5031/countries/${ params.id }`);
 
    if (response.ok) {
        const country = await response.json();
        return json(country, { status: 200 });
    } else {
        return json({
            status: response.status,
            statusText: response.statusText
        });
    }
}