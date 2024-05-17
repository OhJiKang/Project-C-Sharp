const Priorityurl = `/api/priority`

async function findPriorityById(id) {
    let result = await fetch(`${Priorityurl}/GetByPrioriryId?IDPriority=${id}`, {
        headers: {
            "Content-Type": "application/json"
        },
        method: 'GET',
    });
    result = await result.json();
    return result;
}
