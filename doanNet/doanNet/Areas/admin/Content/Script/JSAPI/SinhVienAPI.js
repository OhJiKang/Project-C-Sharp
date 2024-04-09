let baseURL = "/api"

const url = `${baseURL}/SinhVien`

async function PostSinhVien(SinhVienData) {
    let result = await fetch(`${url}/AddingSinhVien`, {
        headers: {
            "Content-Type": "application/json"
        },
        method: 'POST',
        body: JSON.stringify(SinhVienData),
    });
    result = await result.json();
    console.log(result)
}
async function findSinhVienById(id) {
    let result = await fetch(`${url}/GetByID?id=${id}`, {
        headers: {
            "Content-Type": "application/json"
        },
        method: 'GET',
    });
    const resulttosend = await result.json();
    return resulttosend;
}
async function PutSinhVien(id,SinhVienData) {
    let result = await fetch(`${url}/PutSinhVien?id=${id}`, {
        headers: {
            "Content-Type": "application/json"
        },
        method: 'PUT',
        body: JSON.stringify(SinhVienData),
    });
    result = await result.json();
    console.log(result)
}
