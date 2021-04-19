# TaxApi
Dot Net Core Web Api to Communicate with External Tax Api (e.g. TaxJar)

## TaxApi Detail:

* [Api UML](#api-uml-field) 
* [Api Prerequisite](#api-dependency-field) 
* [Api Architecture](#api-arc-field) 
* [Api Security](#api-security-field) 
* [Api Configuration](#api-config-field) 
* [Api Swagger](#api-swagger-field) 
* [Api in Action](#api-action-field) 
* [Authors](#api-authors-field) 

## <h3 id="api-uml-field">Api UML</h3>

1. Get Tax Rate

    ![image](https://user-images.githubusercontent.com/1794465/115158841-34509b80-a05e-11eb-9326-f15cd2027ef0.png)

    Sequence Source: https://github.com/rajforweb/TaxApi-Dot-Net-Core-App/blob/main/UML/GetTaxRate.yuml
    
2. Calculate Tax for an Order

    ![image](https://user-images.githubusercontent.com/1794465/115158852-43374e00-a05e-11eb-8a52-313ea953b659.png)

    Sequence Source: https://github.com/rajforweb/TaxApi-Dot-Net-Core-App/blob/main/UML/TaxForOrder.yuml
    
## <h3 id="api-dependency-field">Api Prerequisite</h3> 

- Prerequisite : .Net Core 3.1. 
- Dev Tools : VS2019 / VSCode

## <h3 id="api-arc-field">Api Architecture</h3>  

- This Api is build on .Net Core 3.1 which is a lightweight, cross platform and high performance framewrok. 
- Api is build on ![#f03c15](https://via.placeholder.com/15/f03c15/000000?text=+)`Onion Architecture` pattern which provides a better way to build applications for better testability, maintainability, and dependability on the infrastructures like databases and service.

  ![image](https://user-images.githubusercontent.com/1794465/115166472-5c9dc180-a081-11eb-886d-8c3ee254e1df.png)

- TaxApi.Host
    * To Get Tax Rate [Route : /api/Tax/TaxRate]
    * Calculate Tax for an Order [Route: /api/Tax/OrderTax]
    * ActionFilter : Validates consumer and returns 401 unauthorized if consumer not allowed.
    * ExceptionFilter : Catches all exception and returns appropriate error message with status code.  

- TaxApi.Core
    * Service : Enables to communicates with Repositories. One controller will have one Service. Service layer validates the request and populates a valid apiRequest 
               and sends to repository.
    * Repository : Enables to make ApiCall and returns response.
    * Validators : Validates Api request to ensure valid request sent to TaxJarApi.
    * ApiClient : ApiClient makes call to external TaxJar Api using HttpClient.
    * Helpers : This enables to load configured consumers.   
    * Excetpions : This enables custom exception handling and return error message. 
     
- TaxApi.Domain   
    * This layer keep all model & entities required to process a request.

- Unit Tests
    * TaxApi.Host.Tests 
    * TaxApi.Core.Tests           
        * Test Driven development : Xunit enables early detection of failures and provides robust software delivery. XUnit used to test app components.
    
    ![image](https://user-images.githubusercontent.com/1794465/115159047-349d6680-a05f-11eb-9689-d6f50b4f2914.png)


## <h3 id="api-security-field">Api Security</h3>
- TaxApi is Secure and only allowed to Consumer with having valid consumer key. User without valid consumer key won’t be able to use this API and request will fail.
   Please use consumerKey as "f4b358d793ce4105b46d9f055cf53f79" to use this App. This is configured using AppSettings.Json.
  
   e.g. ConsumerKey: ![#f03c15](https://via.placeholder.com/15/f03c15/000000?text=+)`f4b358d793ce4105b46d9f055cf53f79`

## <h3 id="api-config-field">Api Configuration</h3>
- This allows to add consumers with external Tax provider(e.g. TaxJar) URL & their Authentication token. So, this App having capability to onboard a consumer and configure external tax api like TaxJar. As long as data contract not changing this app will handle multiple external Api to get Tax information.
 
    * consumerKey : TaxApi consumer key to access TaxApi.
    * taxApiUrl : Configure external Api (e.g. TaxJarApi) which provides Tax Data.
    * taxApiAuthToken : Configure AuthToken for external Api.  
 
    ![image](https://user-images.githubusercontent.com/1794465/115167507-eb144200-a085-11eb-847c-59cd99d535a2.png)

 
## <h3 id="api-swagger-field">Api Swagger</h3>
   - This provides standard TaxApi documentation and capability to consume it.
          
     ![image](https://user-images.githubusercontent.com/1794465/115150554-dfe5f580-a036-11eb-9443-c3da4e220963.png)

## <h3 id="api-action-field">Api In Action</h3>
   
 1. GetTax Rate:
    * Success
    ![image](https://user-images.githubusercontent.com/1794465/115155595-bc2ea980-a04e-11eb-8414-cb89e7184edd.png)
    
    * Error
    ![image](https://user-images.githubusercontent.com/1794465/115167083-17c75a00-a084-11eb-924b-c0992a1f7ca7.png)

 2. Order Tax:
    * Success
    ![image](https://user-images.githubusercontent.com/1794465/115151201-d5792b00-a039-11eb-883f-0d183aebf069.png)
    
    * Error
    ![image](https://user-images.githubusercontent.com/1794465/115167122-47766200-a084-11eb-9f74-70c8f8f9467b.png)

 3. Invalid Consumer
    
    ![image](https://user-images.githubusercontent.com/1794465/115167881-0df32600-a087-11eb-8d4a-7af08e02f0d0.png)


## <h3 id="api-authors-field">Authors</h3> 
- Raj Kumar
