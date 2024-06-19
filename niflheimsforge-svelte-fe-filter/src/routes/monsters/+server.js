import { json } from '@sveltejs/kit';

export async function GET(request) {
const response = await request.fetch('http://localhost:5031/monsters');
    if (response.ok) {
        const monsters = await response.json();
        return json({
            body: monsters
        });
    } else {
        return json({
            status: response.status,
            statusText: response.statusText
        });
    }
}