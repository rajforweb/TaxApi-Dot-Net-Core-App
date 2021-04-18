# TaxApi
Dot Net Core Web Api to Communicate with External Tax Api (e.g. TaxJar)

## TaxApi Detail:

* [Api UML](#api-uml-field) 
* [Api Dependency](#api-dependency-field) 
* [Api Architecture](#api-arc-field) 
* [Api Security](#api-security-field) 
* [Api Configuration](#api-config-field) 
* [Api Swagger](#api-swagger-field) 
* [Api in Action](#api-action-field) 
* [Authors](#api-authors-field) 

## <h3 id="api-uml-field">Api UML</h3>

## <h3 id="api-dependency-field">Api Dependency</h3> 
TaxApi build on .Net Core 3.1. This can be deployed on web server Or, Docker container with asp net images.

To use docker need to follow below link:
https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/docker/building-net-docker-images?view=aspnetcore-3.1

## <h3 id="api-arc-field">Api Architecture</h3>  

This Api is build on .Net Core 3.1 which is a lightweight, cross platform and high performance framewrok. Api is build on Onion Architecture pattern which provides a better way to build applications for better testability, maintainability, and  dependability on the infrastructures like databases and service.

* <h5 id="api-arc-field">TaxApi.Host</h5>
  Tax Controller enables :
1. To Get Tax Rates.
2. Calculate Tax for an Order.
* <h5 id="api-arc-field">TaxApi.Core</h5>
1. Service Layer : Enables to communicats with Repositories. One controller will have one Service. Service layer validates the request and populates a valid 
                  apiRequest and sends to repository.  
2. Repository Layer : Enables to make ApiCall and returns response.

* <h5 id="api-arc-field">TaxApi.Domain</h5>   
          This layer keep all model.Entities required to proccess request and return response.

* <h5 id="api-arc-field">Unit Tests</h5>
          TaxApi.Host.Tests 
          TaxApi.Core.Tests           
          Test Driven development Xunit enables early detection of failures and provides robust software. XUnit used to test app components.
          
    ![image](https://user-images.githubusercontent.com/1794465/115149600-e07c8d00-a032-11eb-9852-5e3b5b717239.png)

## <h3 id="api-security-field">Api Security</h3>
   TaxApi is Secure and only allowed to Consumer with having valid consumer key. User without valid consumer key won;t be able to use this API and request will fail.
   Please use consumerKey as "f4b358d793ce4105b46d9f055cf53f79" to use this App. 
  
   e.g. ConsumerKey: ![#f03c15](https://via.placeholder.com/15/f03c15/000000?text=+)`f4b358d793ce4105b46d9f055cf53f79`

## <h3 id="api-config-field">Api Configuration</h3>
   This allows to add consumers with external Tax provider(e.g. TaxJar) URL & their Authentication token. So, this App having capability to onbaord a consumer and     
   configure exteral tax api like TaxJar. As long as data contract not changing this app will handle multiple external Api to get Tax information.
 
## <h3 id="api-swagger-field">Api Swagger</h3>
   This provides standard TaxApi documentation and capability to consumer it.
          
   ![image](https://user-images.githubusercontent.com/1794465/115150554-dfe5f580-a036-11eb-9443-c3da4e220963.png)

## <h3 id="api-action-field">Api In Action</h3>
   
   1. GetTax Rate:
   
   ![image](https://user-images.githubusercontent.com/1794465/115150756-cdb88700-a037-11eb-8da8-64cd1fa4a0ed.png)
   
   2. Order Tax:
    
   ![image](https://user-images.githubusercontent.com/1794465/115151201-d5792b00-a039-11eb-883f-0d183aebf069.png)

## <h3 id="api-authors-field">Authors</h3> 
- Raj Kumar
