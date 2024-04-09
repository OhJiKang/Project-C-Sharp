let baseURL = "/api"
const url = `${baseURL}/attendance`

async function putAttendance(AttedanceData,id) {
    let result = await fetch(`${url}/PutAttendance?id=${id}`, {
        headers: {
            "Content-Type": "application/json"
        },
        method: 'PUT',
        body: JSON.stringify(AttedanceData),
    });
    result = await result.json();
}
async function postAttendance(AttedanceData) {
    let result = await fetch(`${url}/AddingAttendance`, {
        headers: {
            "Content-Type": "application/json"
        },
        method: 'POST',
        body: JSON.stringify(AttedanceData),
    });
    result = await result.json();
}
async function getAttendanceBySinhVienID(SinhVienID) {
    let result = await fetch(`${url}/GetAllAttendanceBySinhVienID?id=${SinhVienID}`, {
        headers: {
            "Content-Type": "application/json"
        },
        method: 'GET',
    });
    result = await result.json();
}
