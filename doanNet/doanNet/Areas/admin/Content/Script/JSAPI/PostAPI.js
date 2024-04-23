let baseURL = ""
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
    data.append("PostTitle", PostData.PostTittle);
    data.append("PostDetail", PostData.PostDetail)
    data.append("meta", PostData.meta)
    data.append("PostImage", PostData.PostImage)
    data.append("CategoryList", JSON.stringify(PostData.CategoryList))
    data.append("IDAccount", PostData.IDAccount);
    $.ajax({
        type: "POST",
        url: `${mistakeURL}/AddingPost`,
        contentType: false,
        processData: false,
        data: data,
        success: function () {

        },
        error: function () {

        }
    });
    /*let result = await fetch(`${url}/AddingPost`, {
        method: 'POST',
        body: data,
    });
    result = await result.json();*/
}