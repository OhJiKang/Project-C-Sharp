let baseURL = "/api"
const url = `${baseURL}/post`

function putPost(PostData, id) {
    let result = await fetch(`${url}/PutPost?id=${id}`, {
        headers: {
            "Content-Type": "application/json"
        },
        method: 'PUT',
        body: JSON.stringify(PostData),
    });
    result = await result.json();
}
function postPost(PostData) {
    let result = await fetch(`${url}/AddingPost`, {
        headers: {
            "Content-Type": "application/json"
        },
        method: 'POST',
        body: JSON.stringify(PostData),
    });
    result = await result.json();
}