document.addEventListener('DOMContentLoaded',function()
{
    document.getElementById("EnterDetails").addEventListener("submit",function(event)
        {
            event.stopPropagation();
            event.preventDefault();
            if (EnterDetails.Number.value == '' && EnterDetails.Name.value == '')
            {
                alert('You have to Enter at least one filed');
                return false;
            }
            else
                {
                    var token = document.cookie
                    .split(';')
                    .find(row=>row.startsWith('access_token='))
                    .split('=')[1];
                    

                    fetch(window.location.origin + `/Account/id/${EnterDetails.Name.value}`,
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
                            .then(data=>{
                                const number = data
                                if (EnterDetails.Number.value == '')
                                {
                                    
                                    window.location.href=`Details/${number}`;
                                }
                                else 
                                {
                                    window.location.href=`Details/${EnterDetails.Number.value}`;
                                }
                            })

                    
                    
                }
        })
});