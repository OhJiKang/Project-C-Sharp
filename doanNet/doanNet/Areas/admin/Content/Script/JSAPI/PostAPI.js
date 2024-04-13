let baseURL = "/api"
const url = `${baseURL}/post`

async function putPost(PostData, id) {
    let result = await fetch(`${url}/PutPost?id=${id}`, {
        headers: {
            "Content-Type": "application/json"
        },
        method: 'PUT',
        body: JSON.stringify(PostData),
    });
    result = await result.json();
}
async function postPost(PostData) {
    var data = new FormData()
    console.log(PostData)
    data.append("PostTittle", PostData.PostTittle);
    data.append("PostDetail", PostData.PostDetail)
    data.append("meta", PostData.meta)
    data.append("PostImage", PostData.PostImage)
    data.append("CategoryList", PostData.CategoryList)
    data.append("IDAccount", PostData.IDAccount)
    let result = await fetch(`${url}/AddingPost`, {
        method: 'POST',
        body: data,
    });
    result = await result.json();
}