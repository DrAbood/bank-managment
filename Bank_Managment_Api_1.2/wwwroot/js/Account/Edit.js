const id = location.pathname.split('/')[3];
var token = document.cookie
    .split(';')
    .find(row=>row.startsWith('access_token='))
    .split('=')[1];

fetch(window.location.origin + `/Account/${id}`,
{
    method: 'Get',
    headers:{
    'content-type':'application/json',
    'Authorization': `Bearer ${token}`
    } 
})
    .then(res =>
    {
        if (res.status >= 500)
        {
            window.location.href = window.location.origin +"/Errors"
        }
        else if(res.status == 401)
        {
            alert("You Don't Have Permission ")
            window.location.href = window.location.origin +"/Account/Main"

        }
        else if (!res.ok)
        {
            alert("The Account Doesn't Exist")
            window.location.href = window.location.origin +"/Account/Main"
            return;
        }
        return res.json();
    })
    .then(data =>
    {
            // const HolderName = `<li>${data.HolderName}</li>`
            // const Balance = `<li> ${data.Balance}</li>`
            const AccountNumbers = `<li> ${data.Numbers}</li>`
            // const PhoneNumber = `<li> ${data.AssociatedPhoneNumber}</li>`

            document.querySelector('ul').insertAdjacentHTML('beforeend',AccountNumbers)

            document.getElementById("HolderName").value = data.HolderName;

            document.getElementById("PhoneNumber").value = data.AssociatedPhoneNumber;
    })
    .catch(error => console.log(error));

document.getElementById("EditForm").addEventListener("submit", function(e) {
    e.preventDefault();

    const updatedData = {
        HolderName: document.getElementById("HolderName").value,
        AssociatedPhoneNumber: document.getElementById("PhoneNumber").value
    };

    fetch(`/Account/patch/${id}`, {
        method: 'PATCH',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${token}`
        },
        body: JSON.stringify(updatedData)
    })
    .then(res => {
        if(res.status == 401)
        {
            alert("You Don't Have permission")
            window.location.href = `${window.location.origin}/Account/Main`
            return;
        }
        else if (res.status >= 500)
        {
            window.location.href = `${window.location.origin}/Errors`
            return;
        }
        else if(!res.ok)
        {
            alert(`Something Went Wrong ${res.status}`)
            window.location.href = `${window.location.origin}/Account/Main`
            return;
        }
        else if (res.status ==204)
        {
            console.log("Success");
            window.location.href = window.location.origin + "/Account/Main"
            alert("The Account have been Successfully Edited")
        }
        res.json()
    })
    .catch(err => console.error(err));
});
