# SongLibrary

Technologies Used

    Backend: ASP.NET Core 8.0

    Authentication: Azure Active Directory

    Containerization: Docker

    Deployment: Azure

API Endpoints

    GET /song
    GET /song/{id}
    POST /song
    PUT /song
    DELETE /song/{id}

Deployment to Azure

    1. Build the project on Visual Studio
    
    2. Create resource group on Azure and push Docker Image to Azure Container Registry (ACR):    
      az group create --name myResourceGroup --location westus2
      az acr create --resource-group myResourceGroup --name songcontainerregistry --sku Basic
      az acr login --name songcontainerregistry
    
      docker tag songlibrary:dev songcontainerregistry.azurecr.io/song-library:latest
      docker push songcontainerregistry.azurecr.io/song-library:latest

    3. Deploy to Azure Container Instances (ACI):
      az container create \
        --resource-group MyResourceGroup \
        --name song-library \
        --image MyAcr.azurecr.io/song-library:latest \
        --dns-name-label song-library-dns \
        --ports 80 \
        --os-type Windows \
        --cpu 2 \
        --memory 1
