
function DeleteThis_onclick(chkVal) {
 
         
       if(chkVal==true)
       {
        return true;
       } 
      
        for(i = 0; i < document.forms[0].elements.length; i++) {

            elm = document.forms[0].elements[i];
            
            if (elm.type == 'checkbox') {
                arrayOfStrings = elm.name.split(':')
                   
             if(arrayOfStrings[arrayOfStrings.length - 1] == "CheckAll")
             {
                    
                    elm.checked = false;
                    break;
                    
                }
            }
        }
     
   }


function CheckAll_onclick(chkVal) 
{    
    for(i = 0; i < document.forms[0].elements.length; i++) 
    {
        elm = document.forms[0].elements[i];
       
        if (elm.type == 'checkbox') 
        {           
            arrayOfStrings = elm.name.split(':')
            
            if(arrayOfStrings[arrayOfStrings.length - 1] == "DeleteThis")           
            {                                
                  elm.checked = chkVal;                
            }                          
        }
    }    
}

function DeleteThisEx_onclick(chkVal) {
 
         
       if(chkVal==true)
       {
        return true;
       } 
      
        for(i = 0; i < document.forms[0].elements.length; i++) {

            elm = document.forms[0].elements[i];
            
            if (elm.type == 'checkbox') {
                arrayOfStrings = elm.name.split(':')
                   
             if(arrayOfStrings[arrayOfStrings.length - 1] == "CheckAllExtra")
             {
                    
                    elm.checked = false;
                    break;
                    
                }
            }
        }
     
   }


function CheckAllEx_onclick(chkVal) 
{    
    for(i = 0; i < document.forms[0].elements.length; i++) 
    {
        elm = document.forms[0].elements[i];
       
        if (elm.type == 'checkbox') 
        {           
            arrayOfStrings = elm.name.split(':')
            
            if(arrayOfStrings[arrayOfStrings.length - 1] == "DeleteThisExtra")           
            {                                
                  elm.checked = chkVal;                
            }                          
        }
    }    
}


function popup(mylink, windowname)
    {
      if (! window.focus)return true;
         var href;
         if (typeof(mylink) == 'string')
            href=mylink;
          else
            href=mylink.href;
            window.open(href, windowname, 'width=600,height=400,scrollbars=yes');
          return false;
    }
    
function closewinCust(CustomerCode)
        {      
         window.opener.document.form1.txtCustomerCode.value = CustomerCode;       
         window.close();      
        }
function closewinEmp(EmployeeCode)
        {
        opener.document.Form1.txtEmployeeCode.value=EmployeeCode;
        this.close();
        }
function closewin(ProductCode)
        {
        opener.document.Form1.txtProductCode.value=ProductCode;
        this.close();
        }

    
function closewinInvoice(InvoiceNo)
        {      
         window.opener.document.form1.txtInvoiceNo.value = InvoiceNo;       
         window.close();      
        }
function closewinProductCode(ProductCode)
        {      
         window.opener.document.form1.txtProductCode.value = ProductCode;       
         window.close();      
        }

