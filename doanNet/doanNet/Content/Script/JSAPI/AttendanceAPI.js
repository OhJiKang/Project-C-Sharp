let baseURL = "/api"
const url = `${baseURL}/attendance`

function Postattendance(AttedanceData) {
    axios({
        method: 'post', 
        url: `${url}/AddingAttendance`,
        data: {
            "IsAttend": AttedanceData.IsAttend,
            "Reason": AttedanceData.Reason,
            "IDSinhVien": AttedanceData.IDSinhVien,
            "IDAccount": AttedanceData.IDAccount
        }
    });
}
function Putattendance(id) {
    axios({
        method: 'put',
        url: `${url}/PutAttendance/${id}`,
        data: {
            "IsAttend": AttedanceData.IsAttend,
            "Reason": AttedanceData.Reason,
            "IDSinhVien": AttedanceData.IDSinhVien,
            "IDAccount": AttedanceData.IDAccount
        }
    });

}
