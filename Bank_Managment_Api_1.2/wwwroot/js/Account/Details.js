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
            const HolderName = `<li>${data.HolderName}</li>`
            const Balance = `<li> ${data.Balance}</li>`
            const AccountNumbers = `<li> ${data.Numbers}</li>`
            const PhoneNumber = `<li> ${data.AssociatedPhoneNumber}</li>`

            document.querySelector('ul').insertAdjacentHTML('beforeend',AccountNumbers)

            document.querySelector('ul').insertAdjacentHTML('beforeend',HolderName)
            
            document.querySelector('ul').insertAdjacentHTML('beforeend',Balance)
            
            document.querySelector('ul').insertAdjacentHTML('beforeend',PhoneNumber)

    })
    .catch(error => console.log(error));

function DeleteAccount()
{

    const id = location.pathname.split('/')[3];

    const token = document.cookie
            .split(';')
            .find(row=>row.startsWith('access_token='))
            .split('=')[1];
    fetch(`${window.location.origin}/Account/delete/${id}`,
        {
            method: 'DELETE',
            headers: {'Authorization': `Bearer ${token}` }
        }
    )
    .then(res => {
        // console.log(BankNumber)
        
        if (res.status == 401)
        {
            alert("You Have No Permession")
            window.location.href = window.location.origin + "/Account/Main"
            return;
        }
        else if (res.status >= 500)
        {
            window.location.href = window.location.origin + "/Errors"
            return;
        }
        else if (!res.ok)
        {
            alert(`There is an error ${res.status}`)
            window.location.href = window.location.origin + "/Account/Main"
            return;

        }
        else if (res.status ==204)
        {
            console.log("Success");
            window.location.href = window.location.origin + "/Account/Main"
            alert("The Account have been Successfully deleted")
        }
        
        return res.json();
    })
    .then(data =>{


    })
    .catch(error => {
        console.log(error);
    })
}

function EditAccount()
{
    const id = location.pathname.split('/')[3];
    window.location.href = `${window.location.origin}/Account/Edit/${id}`
}