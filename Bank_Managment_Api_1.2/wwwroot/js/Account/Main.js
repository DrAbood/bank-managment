document.addEventListener('DOMContentLoaded',function()
{
    // const inputs = Array.from(
    //     document.querySelectorAll('input[name=Name],input[name=Number]')
    // );
    // const inputListener = e=> {
    //     inputs
    //         .filter(i=>i !== e.target)
    //         .forEach(i => (i.required=!e.target.value.length));
    // };
    // inputs.forEach(i=>i.addEventListener('input',inputListener));

//     const inputs = Array.from(
//     document.querySelectorAll('input[name=Name], input[name=Number]')
//   );

//   const inputListener = e => {
//     inputs
//       .filter(i => i !== e.target)
//       .forEach(i => (i.required = !e.target.value.length));
//   };

//   inputs.forEach(i => i.addEventListener('input', inputListener));

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

                    if (EnterDetails.Number.value == '')
                    {
                        
                        window.location.href=`Details/${EnterDetails.Name.value}`;
                    }
                    else 
                    {
                        window.location.href=`Details/${EnterDetails.Number.value}`;
                    }
                    
                }
        })
});