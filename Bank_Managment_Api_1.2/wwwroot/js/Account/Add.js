document.addEventListener('DOMContentLoaded',function(){
    document.getElementById("AddAccountForm").addEventListener('submit', function(event)
    {
        event.stopPropagation();
        event.preventDefault();
        
        newAccount = 
        {
            HolderName: $("#NameInput").val(),
            AssociatedPhoneNumber: $("#PhoneNumberInput").val(),
            Balance: parseFloat($("#BalanceInput").val()),
            DateOfBirth: new Date($("#Birth").val()).toISOString().split('T')[0], 
            CategoryId: parseInt($("#CategoryIdInput").val(),10),
            UserId: parseInt($("#UserIdInput").val(), 10),
            IsActive: $("#isActiveInput").is(":checked")
        }
        const token = document.cookie
            .split(';')
            .find(row=>row.startsWith('access_token='))
            .split('=')[1];

        fetch('http://'+ window.location.host + '/Account', {
            method: 'POST',
            headers:{
                'content-type':'application/json',
                'Authorization': `Bearer ${token}`
            },
            body: JSON.stringify(newAccount),
            // credentials: 'include'
        }).then( async res => {
            if (res.status == 400)
            {
                const errorData = await res.json();
                if(errorData.errors && errorData.errors.DateOfBirth)
                {
                    alert(errorData.errors.DateOfBirth[0])
                }
                

            }
            else if (!res.ok)
            {
                console.log(token)
                console.log('problem');
                // console.log(res);
                alert("there is an error");
                
                return;
            }
            else if (res.status >= 500)
            {
                window.location.href= window.location.origin + "/Errors"
            }
            
            else
            {
                console.log('sucess');
                // console.log(res);
                
                window.location.href = 'Main';
                alert("sucessfuly Account Created")
            }
        })
        .catch(error =>{
            console.log(error)
        })
        
    }, true);
}, true);