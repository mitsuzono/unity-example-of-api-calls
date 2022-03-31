# unity-example-of-api-calls
This Unity application is an example of calling Azure Functions.

## Requirement
- Unity
    - https://unity3d.com/jp/get-unity/download
- Azure Functions Core Tools
    - https://github.com/Azure/azure-functions-core-tools

## Installation
### Publish the Functions project to Azure
- VS: https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-your-first-function-visual-studio#publish-the-project-to-azure
- VS Code: https://docs.microsoft.com/en-us/azure/azure-functions/create-first-function-vs-code-csharp?tabs=in-process#publish-the-project-to-azure

### Setup to call APIs from Unity
Get function URL and set the URL to `/Example of API calls/Assets/Scripts/ApiCaller.cs`
https://docs.microsoft.com/ja-jp/azure/azure-functions/functions-create-function-app-portal#test-the-function

```csharp
public class ApiCaller : MonoBehaviour
{
    private readonly string FUNCTION1_URL = "https://<YOUR_FUNCTIONS_NAME>.azurewebsites.net/api/Function1?code=<YOUR_FUNCTION1_FUNCTION_KEY>";

    ...

```

## Usage
Open `/Example of API calls` directory as Unity project and open `/Example of API calls/Assets/Scenes/SampleScene.unity` in Unity editor
