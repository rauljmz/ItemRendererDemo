# ItemRenderer Demo

Showcases how to use a single component to display a series of _widgets_ on the page and use docker in your development environment. 
See the following blog posts for more details:

* [Speed! - Bonus - Development with Docker](https://blog.rauljimenez.co.uk/speed-bonus-development-with-docker)
* [Item Renderer](https://blog.rauljimenez.co.uk/sitecore-item-renderers)

## Prerequisites
1. Install [Docker for Windows ](https://www.docker.com/docker-windows)
1. Clone Per Manniche Bering's [sitecore-nine-docker](https://github.com/pbering/sitecore-nine-docker) repository
1. Follow his *Preparations* instructions detailed in the README.

## Usage
1. From the repository root run `docker-compose up -d`
1. Run `nuget restore` (you can also simply build the solution using Visual Studio; you can [download nuget](https://www.nuget.org/downloads) if needed)
1. Run `msbuild /p:DeployOnBuild=true /p:PublishProfile=DeployToFolder .\ItemRendererDemoWebsite` (assumes msbuild is in your path)
1. Obtain the IP of the Sitecore instance `docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' ItemRendererDemoWebsite_cm`
1. Using the IP obtained above, access `/unicorn.aspx` (you will have to log in as admin) and choose the **Sync** option
1. Navigate to the `/great-article` page. It should show a page displayed using ItemRenderers

When you have finished working with the Sitecore installation you have two options:

* `docker-compose stop` - it will stop the containers so they do not use resources, but everything is still persisted in the HD. Just run again `docker-compose up -d` and you can continue where you left off.
* `docker-compose down` - it will destroy the containers. All traces of the Sitecore installations are removed. To start it again you will have to run all the previous *usage* steps again. 