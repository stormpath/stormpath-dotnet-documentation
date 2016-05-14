.. _email_verification:

Email Verification
==================

Stormpath provides a self-service email verification flow for new accounts, where users will need to verify their email address before their account is enabled. This library adds this functionality to your |framework| application automatically if it is enabled in your Stormpath Directory.

By default, this library will serve an Email Verification form and callback handler at ``/verify``, *if* the Verification Email workflow is enabled in Stormpath. You can change these URIs, or disable the feature entirely if you wish (see :ref:`email_verification_configuration`).


Enabling the Workflow
---------------------

To enable email verification, you need to configure the Stormpath Directory your application is using. Follow these steps:

1. Use the `Stormpath Admin Console`_ to find the Stormpath Directory linked to your Application.
2. Navigate to the Workflows section and enable the **Verification Email** workflow.
3. Modify the **Link Base URL** to point to your application:

.. code-block:: sh

    http://yourapplication.com/verify

.. note::
  The ``/verify`` route is automatically provided by this library. If you want to change the route URI, see :ref:`email_verification_configuration`.


How it Works
------------

After enabling the workflow in Stormpath, restart your |framework| application. The behavior of the ``/register`` route will change:

* New accounts will initially be in an **unverified** state, and the user will receive an email with a link.
* Clicking that link will take the user to ``/verify``, which will automatically use the token provided in the email to verify their account.
* The user can now log in as usual.
* Additionally, visiting ``/verify`` directly will allow the user to request a new link.


.. _email_verification_configuration:

Configuration Options
---------------------

This feature supports several options that you can configure using code or markup (see the :ref:`Configuration` section):

* **enabled**: Whether the feature is enabled. (Default: ``null``, see note below)
* **uri**: The path for this feature. (Default: ``/verify``)
* **nextUri**: The location to send the user after verifying their email. (Default: ``/login?status=verified``, but see :ref:`email_verification_auto_login`)
* **view**: The view to render; see :ref:`templates`. (Default: ``verify``)

.. note::
  The **enabled** property can be set to ``true``, ``false``, or ``null``. A value of ``null`` means that the route will automatically be enabled if the default Account Store for the current Stormpath application has the Verification Email workflow enabled.

.. note::
  Any unchanged options will retain their default values. See the :ref:`email_verification_default_configuration` section to view the defaults.


Configuration Example
.....................

You could, for example, change the endpoint path by setting this configuration (shown as YAML):

.. code-block:: yaml

  web:
    verifyEmail:
      uri: "/verifyEmail"

You could also set this configuration via code:

.. only:: aspnetcore

  .. literalinclude:: code/email_verification/aspnetcore/configure_uri.cs
    :language: csharp

.. only:: aspnet

  .. todo::
    Add code

.. only:: nancy

  .. todo::
    Add code


See the :ref:`configuration` section for more details on how configuration works, or :ref:`email_verification_default_configuration` to see the default values for this route.


.. _email_verification_auto_login:

Auto Login
----------

Our library implements the most secure workflow by default: the user must log in after verifying their account.

By default, the user is redirected to ``/login?status=verified`` (the value of ``verifyEmail.nextUri``), which renders the login form with a status message indicating that the account has been successfully verified.

If :ref:`auto_login` is enabled, the user will be automatically logged in after they reset their password. The user will **not** be redirected to ``verifyEmail.nextUri``, but instead will be redirected to ``register.nextUri``.


Mobile/JSON API
---------------

If you are using this library from a mobile application, or a client framework like Angular or React, you'll interact with this endpoint via GET and POST requests.

Verifying a User
................

To verify a user, make a GET request with the ``sptoken`` from the verification email:

.. code-block:: http

  GET /verify?sptoken=<token>
  Accept: application/json

If validation succeeds, the endpoint will respond with ``200 OK``.

If an error occurs, you'll get an error response:

.. code-block:: json

  {
    "status": 400,
    "message": "sptoken parameter not provided."
  }


Requesting a New Link
.....................

To request a new link, make a POST request:

.. code-block:: http

  POST /verify
  Accept: application/json
  Content-Type: application/json

  {
    "email": "foo@bar.com"
  }

The endpoint will always respond with ``200 OK``, regardless of whether the email address is valid.



.. _email_verification_default_configuration:

Default Configuration
---------------------

Options that are not overridden by explicit configuration (see :ref:`configuration`) will retain their default values.

For reference, the full default configuration for this route is shown as YAML below:

.. code-block:: yaml

  web:
    verifyEmail:
      enabled: null
      uri: "/verify"
      nextUri: "/login?status=verified"
      view: "verify"

.. tip::
  You can also refer to the `Example Stormpath configuration`_ to see the entire default library configuration.


.. _Stormpath Admin Console: https://api.stormpath.com
.. _Example Stormpath configuration: https://github.com/stormpath/stormpath-framework-spec/blob/master/example-config.yaml
