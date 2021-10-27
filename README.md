# battlesnake-az-func
Testing hosting a battlesnake on Azure functions





## Run game server locally with az func


Start and watch the func app
```
$ dotnet watch msbuild /t:RunFunctions
```

Run the game server in solo-mode
```
$ battlesnake play -W 11 -H 11 --name Anac#nda --url http://localhost:7071/api/anaconda -g solo -v
```