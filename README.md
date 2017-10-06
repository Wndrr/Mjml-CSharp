# /!\ WARNING /!\
The library is currently being completly re-written. Below is a simple list of the major changes that will have to be taken into account for the next release

- [ ] Convert from .NET Framework 4.x to .NET Standard 2.0
- [ ] Remove installation of node and npm from the library's tasks. Use system-installed node (couldn't be bothered to handle cross-plateform node install)

The usage of the library sholdn't change at all, but the internals will see a massive update. The installation process will be different too. The library's performances should improve because of the remove overhead.

# Mjml-CSharp

A C#.NET Wrapper for the [Mjml framework](https://mjml.io/)

The list of currently planned features and their status can be found on the project's [dashboard](https://github.com/Wndrr/Mjml-CSharp/projects/1).

For feature requests and troubleshooting you can [open an issue](https://github.com/Wndrr/Mjml-CSharp/issues/new).

## Getting Started

This page will give you instructions to install the library, and the minimal code to get started using it.

### Installing

The latest release can downloaded from [NuGet.org](https://www.nuget.org/packages/Wndrr.Mjml.CSharp). 
You can install the package using the VisualStudio NuGet integration by searching for the `Wndrr.Mjml.CSharp` package.

### Minimal code

#### The simple way

All you really need to do in the code is to instanciate a `Mjml` object and then call the `Render` method

    var mjml = new Mjml();
    var outputHtml = mjml.Render("mjml code");

The `Render` method will return a string containing the HTML compiled from the input MJML code.

#### Two more simple ways

You can also pass an array of strings, or multiple strings as separate parameters to the `Render` method as follow.

    var outputHtml = mjml.Render(new[]
    {
        "mjml code", 
        "more mjml code"
    });

or

    var outputHtml = mjml.Render("mjml code", "more mjml code"); // You can add as many parameters as you wish

Both of these multiple-input versions will return an array of strings.

## Deployment

No special actions should be needed to go from dev to test/prod server.

## Built With

* [Mjml framework](https://mjml.io/) - Responsive email templating framework engine thingy thingy (these guys are cool af)
* [Node](https://nodejs.org) - eh, Node. I don't actually know much about the thing but it works so ye.
* [DotNetZip.Semverd](https://github.com/haf/DotNetZip.Semverd) - Thanks to [haf](https://github.com/haf)
* [Automation_PowerShell_3.0](https://www.nuget.org/packages/System.Management.Automation_PowerShell_3.0) - Thx to Microsoft Corporation

## Contributing

If you are willing to improve this project, read the [contributing](CONTRIBUTING.md) page.

## Versioning

The project follows some sort of SemVer convention, but out of laziness not all rules are actually applied on the NuGet repo. This simply means that I will only push on [NuGet](https://www.nuget.org/packages/Wndrr.Mjml.CSharp) the stable release which will induce a non-consecutive versioning style.

Versioning should be following the [SemVer v2.0.0](http://semver.org/) rules quite (well, kind-of-maybe-somewhat) well on the [MyGet repo](https://www.myget.org/feed/wndrr-perso/package/nuget/Wndrr.Mjml.CSharp)

You can find the released versions on the [tags page](https://github.com/Wndrr/Mjml-CSharp/tags)

The latest in-dev versions can be found on the [MyGet repo](https://www.myget.org/feed/wndrr-perso/package/nuget/Wndrr.Mjml.CSharp)

This project uses some sort of variation of [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/Wndrr/Mjml-CSharp/tags).

## Authors

* **Mathieu Viales Aka. Wndrr** 
Fine me on
- [Github](https://github.com/Wndrr)
- [StackOverflow](https://stackoverflow.com/users/6838730/wndrr)
- [MyBlog](http://wndrr.ovh/)

## License

This project is licensed under the MIT License - see the [license](LICENSE) file for details

## Acknowledgments

* Thanks to the guys that made Node.exe (whoever they are)
* Thanks to the guys that made the MJML framework, give them a hi on [their slack](https://mjml.slack.com/messages/C12HESC2G/)
* Special thanks to Iryusa and Dalefish for the help and directions
* Super Thanks to Iryusa for the code sample

