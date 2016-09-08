# Mailosaur .NET Client Library

[Mailosaur](https://mailosaur.com) allows you to automate tests involving email. Allowing you to perform end-to-end automated and functional email testing.

[![Build Status](https://travis-ci.org/mailosaur/mailosaur-dotnet.svg?branch=master)](https://travis-ci.org/mailosaur/mailosaur-dotnet)

## Installation

```
nuget install mailosaur
```

## Documentation and usage examples

[Mailosaur's documentation](https://mailosaur.com/docs) includes all the information and usage examples you'll need.

## Running tests

Once you've cloned this repository locally, you can simply run:

```
dotnet restore

export MAILOSAUR_MAILBOX_ID=yourmailbox
export MAILOSAUR_API_KEY=yourapikey

dotnet test
```

## Contacting us

You can get us at [support@mailosaur.com](mailto:support@mailosaur.com)

## License

Copyright (c) 2016 Mailosaur Ltd
Distributed under MIT license.
