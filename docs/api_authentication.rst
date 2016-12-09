.. _api_authentication:

API authentication
==================

If you're building an API service that other developers will consume, the Stormpath |framework| library provides two ways to authenticate users and machines:

  * For simple services that will always use HTTPS, you can use :ref:`http_basic`.

  * For services that require stronger security, you can use the :ref:`oauth2_client_credentials_grant`.

If you're building a web or mobile application, head over to :ref:`authentication` instead.


.. _issuing_api_keys:

Issuing API keys
----------------

Regardless of the authentication mechanism you choose, you'll need a way to distribute API keys to your users.

You can manually provision API keys for your users by using the `Stormpath Admin Console`_:

#. Click on the Accounts tab
#. Open up the details for the Account you want to create an API key for
#. Expand the Security Credentials panel
#. Click Create API Key

You'll need a way to securely distribute these API keys to your users. In a production application, you can use the `Stormpath .NET SDK`_ to generate the API keys programmatically and allow your users to view or download the key pairs.

.. _http_basic:

HTTP Basic authentication
-------------------------


.. _oauth2_client_credentials_grant:

OAuth 2.0 client credentials grant
----------------------------------


.. todo::

  HTTP Basic Authentication
  .. -------------------------

  This strategy makes sense if you are building a simple API service that does
  not have complex needs around authorization and resource control.  This strategy
  is simple because the developer simply supplies their API keys on every request
  to your server.

  Once the developer has their API keys, they will use them to authenticate with your
  API.  For each request they will set the ``Authorization`` header, like this::

      Authorization: Basic <Base64UrlSafe(apiKeyId:apiKeySecret)>

  How this is done will depend on what tool or library they are using.  For example,
  if using curl:

  .. code-block:: sh

    curl -v --user apiKeyId:apiKeySecret http://localhost:3000/secret

  Or if you're using the ``request`` library:

  .. code-block:: javascript

    var request = require('request');

    request({
      url: 'http://localhost:3000/secret',
      auth: {
        user: 'apiKeyId',
        pass: 'apiKeySecret'
      }
    }, function (err, res){
      console.log(res.body);
    });

  You will need to tell your application that you want to secure this endpoint and
  allow basic authentication.  This is done with the ``apiAuthenticationRequired``
  middleware::

      app.get('/secret', stormpath.apiAuthenticationRequired, function (req, res) {
        res.json({
          message: "Hello, " + req.user.fullname
        });
      });

todo

.. todo::

  OAuth2 Client Credentials
  .. -------------------------

  If you are building an API service and you have complex needs around
  authorization and security, this strategy should be used.  In this situation
  the developer does a one-time exchange of their API Keys for an Access Token.
  This Access Token is time limited and must be periodically refreshed.  This adds a
  layer of security, at the cost of being less simple than HTTP Basic
  Authentication.

  If you're not sure which strategy to use, it's best to start with HTTP Basic
  Authentication. You can always switch to OAuth2 at a later time.

  Once a developer has an API Key pair (see above, *Issuing API Keys*), they will
  need to use the OAuth2 Token Endpoint to obtain an Access Token.  In simple
  HTTP terms, that request looks like this::


      POST /oauth/token
      Host: myapi.com
      Content-Type: application/x-www-form-urlencoded
      Authorization: Basic <Base64UrlSafe(apiKeyId:apiKeySecret)>

      grant_type=client_credentials

  How you construct this request will depend on your library or tool, but the key
  parts you need to know are:

    * The request must be a POST request.
    * The content type must be form encoded, and the body must contain
      ``grant_type=client_credentials``.
    * The Authorization header must be Basic and contain the Base64 Url-Encoded
      values of the Api Key Pair.

  If you were doing this request with curl, it would look like this:

  .. code-block:: sh

    curl -X POST --user api_key_id:api_key_secret http://localhost:3000/oauth/token -d grant_type=client_credentials

  Or if using the ``request`` library:

  .. code-block:: javascript

    request({
      url: 'http://localhost:3000/oauth/token',
      method: 'POST',
      auth: {
        user: '1BWQHHJCOW90HI7HFQ5LTD6O0',
        pass: 'zzeu+NwmicjtJ9yDJ2KlRguC+8uTjKVm3AMs80ah6hw'
      },
      form: {
        'grant_type': 'client_credentials'
      }
    },function (err,res) {
      console.log(res.body);
    });

  If the credentials are valid, you will get an Access Token response that looks
  like this::

      {
        "access_token": "eyJ0eXAiOiJKV1QiL...",
        "token_type": "bearer",
        "expires_in": 3600
      }

  The response is a JSON object which contains:

  - ``access_token`` - Your OAuth Access Token.  This can be used to authenticate
    on future requests.
  - ``token_type`` - This will always be ``"bearer"``.
  - ``expires_in`` - This is the amount of seconds (*as an integer*) for which
    this token is valid.

  With this token you can now make requests to your API.  This request is simpler,
  as only thing you need to supply is ``Authorization`` header with the Access
  Token as a bearer token.  If you are using curl, that request looks like this:

  .. code-block:: sh

    curl -v -H "Authorization: Bearer eyJ0eXAiOiJKV1QiL..." http://localhost:3000/secret

  Or if using the ``request`` library:

  .. code-block:: javascript

    request({
      url: 'http://localhost:3000/secret',
      auth: {
        'bearer': 'eyJ0eXAiOiJKV1QiL...'
      }
    }, function (err, res){
      console.log(res.body);
    });

  In order to protect your API endpoint and allow this form of authenetication,
  you need to use the ``apiAuthenticationRequired`` middleware::

      app.get('/secret', stormpath.apiAuthenticationRequired, function (req, res) {
        res.json({
          message: "Hello, " + req.user.fullname
        });
      });

  By default the Access Tokens are valid for one hour.  If you want to change
  the expiration of these tokens you will need to configure it in the server
  configuration, like this::


      app.use(stormpath.init(app, {
        web: {
          oauth2: {
            client_credentials: {
              accessToken: {
                ttl: 3600 // your custom TTL, in seconds, goes here
              }
            }
          }
        }
      }));

.. _Stormpath Admin Console: https://api.stormpath.com/login
.. _Stormpath .NET SDK: https://docs.stormpath.com/csharp/product-guide/latest/
