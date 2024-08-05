# TTM.MiniProject.AzureKeyVault.DotNotCoreWebApi

## Retrieve a Secret from Azure Key Vault using a .NET 8 Application

### Install the necessary NuGet packages:

```sh
Install-Package Azure.Security.KeyVault.Secrets
Install-Package Azure.Identity
```



### Postman URL for Testing
```sh
https://localhost:5001/api/keyvault/get-secret?secretName=mySecret
```

### 1. Create an Azure Key Vault
* Sign in to the Azure Portal:

* Go to Azure Portal.

* Create a Key Vault:

  * Navigate to Create a resource > Security + Identity > Key Vault.

  * Click Create.

  * Enter the necessary details:
  
    * Resource Group: Select or create a new resource group.
    
    * Key Vault Name: Enter a unique name for your Key Vault.
    
    * Region: Select your region.
  
  * Click Review + Create and then Create.


* Navigate to Your Key Vault:

  * After creation, go to your Key Vault from the All resources menu.


### 2. Add a Secret to the Key Vault
* Add a Secret:

  * In the Key Vault, go to Secrets under Settings.
  
  * Click Generate/Import.


  * Enter the Name of the Secret:
  
    * Name: Enter the name of the secret (e.g., test-secret).
    
    * Value: Enter the value of the secret.
  
  * Click Create.


### 3. Get the Key Vault Details
* Key Vault Endpoint:

  * In the Key Vault overview, you will see the DNS Name. This is your Key Vault endpoint.
  
  Example: https://<your-key-vault-name>.vault.azure.net/.

### 4. Register an Application in Microsoft Entra ID
* Create a New App Registration:

  * Go to Microsoft Entra ID > App registrations > New registration.
  
  * Enter the Name of the application (e.g., MyKeyVaultApp).
  
  * Click Register.


* Get the Application (Client) ID and Directory (Tenant) ID:

  * After registration, go to the Overview of the registered application.
  
  * Copy the Application (client) ID and Directory (tenant) ID.
  
  * Application (client) ID is displayed under the application name.
  
  * Directory (tenant) ID is also displayed here.


### 5. Create a Client Secret:
* Go to Certificates & Secrets:

* Go to Certificates & secrets > New client secret.

* Add a description (e.g., KeyVaultSecret).

* Set the Expires option as per your requirement.

* Click Add.


* Copy the Value of the Client Secret:

  * This is your Client Secret.


### 6. Assign Roles Using RBAC
* Go to Access Control (IAM):

  * In your Key Vault, go to Access control (IAM) from the left-hand menu.

* Add a Role Assignment:

* Click on Add and then Add role assignment.

* Select a Role:

  * In the Role dropdown, select Key Vault Secrets User. This role allows read access to secrets in the Key Vault.

* Click Next.


* Assign Access to Your Application:

  * In the Assign access to dropdown, select User, group, or service principal.

* Click on Select members.

* Search for your registered application (e.g., MyKeyVaultApp).

* Select the application and click Select.

* Click Next, then Review + assign.


### Note
You might need additional roles such as Key Vault Administrator if you want to create and manage secrets.


