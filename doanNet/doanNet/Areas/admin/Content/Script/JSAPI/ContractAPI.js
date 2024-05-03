const ContractURL = `/api/contract`

async function putContract(ContractData, id) {
    let result = await fetch(`${ContractURL}/PutContract?id=${id}`, {
        headers: {
            "Content-Type": "application/json"
        },
        method: 'PUT',
        body: JSON.stringify(ContractData),
    });
    result = await result.json();
}
async function postContract(ContractData) {
    
    var data = new FormData()
    data.append("IDSinhVien", ContractData.IDSinhVien);
    data.append("IDCitizen", ContractData.IDCitizen)
    data.append("ProfilePlace", ContractData.ProfilePlace)
    data.append("IDPlace", ContractData.IDPlace)
    data.append("Description", ContractData.Description)
    data.append("TimeExpired", ContractData.TimeExpired);
    data.append("IDPriority", ContractData.IDPriority);
    /*
    ${ContractURL}/AddingContract
    */
    $.ajax({
        type: "POST",
        url: `${ContractURL}/AddingContract`,
        contentType: false,
        processData: false,
        data: data,
        success: function () {

        },
        error: function () {

        }
    });
}
async function GetContractByIDSinhvien(IDSinhVien) {
    let result = await fetch(`${ContractURL}/GetContractByIDSinhvien?IDSinhVien=${IDSinhVien}`, {
        headers: {
            "Content-Type": "application/json"
        },
        method: 'GET',
    });
    result = await result.json();
}
async function ApproveContract(ContractID) {
    let result = await fetch(`${ContractURL}/ApproveContract`, {
        headers: {
            "Content-Type": "application/json"
        },
        method: 'PUT',
        body: JSON.stringify(ContractID),
    });
    result = await result.json();
}
