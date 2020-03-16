# Mjml-CSharp
[![FOSSA Status](https://app.fossa.io/api/projects/git%2Bgithub.com%2FWndrr%2FMjml-CSharp.svg?type=shield)](https://app.fossa.io/projects/git%2Bgithub.com%2FWndrr%2FMjml-CSharp?ref=badge_shield)


A C#.NET Wrapper for the [Mjml framework](https://mjml.io/)

The list of currently planned features and their status can be found on the project's [dashboard](https://github.com/Wndrr/Mjml-CSharp/projects/1).

For feature requests and troubleshooting you can [open an issue](https://github.com/Wndrr/Mjml-CSharp/issues/new).

## Getting Started

This page will give you instructions to install the library, and the minimal code to get started using it.

### Installing

The latest release can downloaded from [NuGet.org](https://www.nuget.org/packages/Wndrr.Mjml.CSharp). 
You can install the package using the VisualStudio NuGet integration by searching for the `Wndrr.Mjml.CSharp` package.

To work, the Mjml wrapper requires you to have NodeJs installed and the Mjml NPM package installed in your `dependencies` or `devDependencies` section.
 
 Example `package.json`

    "devDependencies": {
        "mjml": "^4.6.2"
    }

### Minimal code

#### Initialization

You will need to tell the library where to find node, npm and where to write temporary files. This can be done as follow, before any call to `Render()` is made :

    Mjml.PathRepository.NodePath = @"C:\Program Files\nodejs\node.exe";
    Mjml.PathRepository.TmpPath = Path.GetTempPath();

#### The simple way

Once the paths are set, you can render your MJML templates simply by calling `Mjml.Render(/* mjml */)`

    var mjmlTemplate = "<mjml><mj-body><mj-container><mj-section><mj-column><mj-image width="100" src="/assets/img/logo-small.png"></mj-image><mj-divider border-color="#F45E43"></mj-divider><mj-text font-size="20px" color="#F45E43" font-family="helvetica">Hello World</mj-text></mj-column></mj-section></mj-container></mj-body></mjml>";
    var outputHtml = Mjml.Render(mjmlTemplate);

The `Render` method will return a string containing the HTML compiled from the input MJML code.

## Deployment

Be sure to use apropriate paths for the target server. This should be improved at some point. You can refer to the [related issue](https://github.com/Wndrr/Mjml-CSharp/issues/1)

## Built With

[Mjml framework](https://mjml.io/) - Responsive email templating framework engine thingy thingy (these guys are cool af)

## Contributing

If you are willing to improve this project, read the [contributing](CONTRIBUTING.md) page.

## Versioning

Versioning should be following the [SemVer v2.0.0](http://semver.org/) rules quite well (actually ... kind-of-maybe-somewhat)

You can find the released versions on the [tags page](https://github.com/Wndrr/Mjml-CSharp/tags)

The latest in-dev versions can be found on the [MyGet repo](https://www.myget.org/feed/wndrr-perso/package/nuget/Wndrr.Mjml.CSharp)

## Authors

* Mathieu Viales Aka. **Wndrr** 
  * [Github](https://github.com/Wndrr)
  * [StackOverflow](https://stackoverflow.com/users/6838730/wndrr)
  * [Blog](https://blog-mathieu.viales.fr/)

## License

This project is licensed under the MIT License - see the [license](LICENSE) file for details


[![FOSSA Status](https://app.fossa.io/api/projects/git%2Bgithub.com%2FWndrr%2FMjml-CSharp.svg?type=large)](https://app.fossa.io/projects/git%2Bgithub.com%2FWndrr%2FMjml-CSharp?ref=badge_large)

## Acknowledgments

* Thanks to the guys that made Node.exe (whoever they are)
* Kinda thanks to the makers of npm even tho it's a pain to use it programatically
* Thanks to the guys that made the MJML framework, give them a hi on [their slack](https://mjml.slack.com/messages/C12HESC2G/)
* Special thanks to Iryusa and Dalefish for the help and directions
* Super Thanks to Iryusa for the code sample