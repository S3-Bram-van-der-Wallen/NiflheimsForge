import { json } from '@sveltejs/kit';

export async function GET(request) {
    const response = await request.fetch(`${import.meta.env.VITE_API_ENDPOINT}/countries`);

    if (response.ok) {
        const countries = await response.json();
        return json({
            body: countries
        });
    } else {
        return json({
            status: response.status,
            statusText: response.statusText
        });
    }
}
