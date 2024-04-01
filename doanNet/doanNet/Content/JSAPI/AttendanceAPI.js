import * as ApiConfig from "./APIConfig"
const url = `${ApiConfig.baseURL}/attendance`

export function Postattendance(AttedanceData) {
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
export function Putattendance(int id) {
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
