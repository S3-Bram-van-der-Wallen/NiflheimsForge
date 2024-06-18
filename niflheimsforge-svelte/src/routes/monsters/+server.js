import { json } from '@sveltejs/kit';

export async function GET({ url }) {
    const monsterName = url.searchParams.get('MonsterName');
    const CR = url.searchParams.get('CR');
    
    let apiUrl = 'http://localhost:5031/monsters';

    const params = new URLSearchParams();
    if (monsterName) {
        params.append('MonsterName', monsterName);
    }
    if (CR) {
        params.append('CR', CR);
    }
    
    if (params.toString()) {
        apiUrl += `?${params.toString()}`;
    }

    const response = await fetch(apiUrl);

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
