.. _registration:


Registration
============

The registration feature of this library allows you to use Stormpath to create
new accounts in a Stormpath directory.  You can create traditional password-based accounts, or gather account data from other providers such as Facebook and Google.

By default, this library will serve an HTML registration page at ``/register``.
You can change this URI, or disable the feature entirely if you wish.


.. _registration_configuration:

Configuration options
---------------------

This feature supports several options that you can configure using code or markup (see the :ref:`Configuration` section):

* **enabled**: Whether the feature is enabled. (Default: ``true``)
* **uri**: The path for this feature. (Default: ``/register``)
* **autoLogin**: Whether the user should be logged in after registering. (Default: ``false``)
* **nextUri**: The location to send the user after registering, if **autoLogin** is on. :ref:`social_login` uses this value regardless of **autoLogin**. (Default: ``/``)
* **view**: The view to render; see :ref:`templates`. (Default: ``register``)
* **form**: The fields that will be displayed on the form; see :ref:`register_customizing_form`.

.. note::
  Any unchanged options will retain their default values. See the :ref:`register_default_configuration` section to view the defaults.

Configuration example
.....................

You could, for example, change the endpoint path by setting this configuration (shown as YAML):

.. code-block:: yaml

  web:
    register:
      uri: "/createAccount"

You could also set this configuration via code:

.. only:: aspnetcore

  .. literalinclude:: code/registration/aspnetcore/configure_uri.cs
    :language: csharp

.. only:: aspnet

  .. literalinclude:: code/registration/aspnet/configure_uri.cs
    :language: csharp

.. only:: nancy

  .. .literalinclude:: code/registration/nancy/configure_uri.cs
    :language: csharp

See the :ref:`configuration` section for more details on how configuration works, or :ref:`register_default_configuration` to see the default values for this route.


Pre-registration handler
------------------------

If you need to run code before a registration attempt is sent to Stormpath, you can attach a pre-registration handler when you configure the Stormpath middleware:

.. only:: aspnet

  .. literalinclude:: code/registration/aspnet/preregistration_handler.cs
      :language: csharp

.. only:: aspnetcore

  .. literalinclude:: code/registration/aspnetcore/preregistration_handler.cs
      :language: csharp

.. only:: nancy

  .. .literalinclude:: code/registration/nancy/preregistration_handler.cs
      :language: csharp

The signature of the handler is a ``Func`` that accepts a ``PreRegistrationContext`` and a ``CancellationToken``, and returns a ``Task``. It can be declared as a method instead of with lambda syntax:

.. literalinclude:: code/registration/preregistration_handler_method.cs
    :language: csharp

.. note::

  New user accounts created through an external login mechanism (such as :ref:`social_login`) will trigger both the pre/post-registration handlers and the pre/post-login handlers.

Targeting an Account Store
..........................

If you want to save the new Account in a specific Account Store (rather than the default Account Store for the Application), you can use a pre-registration handler to specify the Account Store:

.. literalinclude:: code/registration/preregistration_target_dir.cs
    :language: csharp


Post-registration handler
-------------------------

If you need to run code after a new account has been created, you can attach a post-registration handler when you configure the Stormpath middleware:

.. only:: aspnet

  .. literalinclude:: code/registration/aspnet/postregistration_handler.cs
      :language: csharp

.. only:: aspnetcore

  .. literalinclude:: code/registration/aspnetcore/postregistration_handler.cs
      :language: csharp

.. only:: nancy

  .. .literalinclude:: code/registration/nancy/postregistration_handler.cs
      :language: csharp

The signature of the handler is a ``Func`` that accepts a ``PostRegistrationContext`` and a ``CancellationToken``, and returns a ``Task``. It can be declared as a method instead of with lambda syntax:

.. literalinclude:: code/registration/postregistration_handler_method.cs
    :language: csharp

.. note::

  New user accounts created through an external login mechanism (such as :ref:`social_login`) will trigger both the pre/post-registration handlers and the pre/post-login handlers.

Saving Custom Data for new Accounts
...................................

A common use for a post-registration handler is to save some data automatically for new Accounts. For example, you could add a default quota value for every new user:

.. literalinclude:: code/registration/postregistration_save_data.cs
    :language: csharp

Addding new Accounts to groups
..............................

Another use for a post-registration handler is automatically adding new Accounts to an existing Group:

.. literalinclude:: code/registration/postregistration_add_group.cs
    :language: csharp


.. _register_customizing_form:

Customizing the form
--------------------

The registration form will render these fields by default, and they will be required:

* First Name (given name)
* Last Name (surname)
* Email
* Password

You can customize the form by simply changing the configuration. For example, while email and password will always be required, you could make first and last name optional. Or, you can ask the user for both an email address and a username. You can also specify your own custom fields, no code required!

.. note::
  If you want to use a custom view for the form, see :ref:`templates`.

Each field item in the ``stormpath.web.register.form.fields`` collection has these configurable properties:

* **enabled**: Whether the field exists on the form is and accepted in POST requests.
* **visible**: Whether the field is visible on the form.
* **required**: Whether an error will be shown if the field is missing.
* **label**: The label text rendered for the control.
* **placeholder**: The placeholder text in the control.
* **type**: The HTML input type of the control.


Making fields optional
......................

If you would like to show a field, but not require it, set the ``required`` property to ``false``, as shown in YAML below:

.. code-block:: yaml

  web:
    register:
      form:
        fields:
          givenName:
            enabled: true
            visible: true
            label: "First Name"
            placeholder: "First Name"
            required: false
            type: "text"
          surname:
            enabled: true
            visible: true
            label: "Last Name"
            placeholder: "Last Name"
            required: false
            type: "text"

Or, in code:

.. only:: aspnetcore

  .. literalinclude:: code/registration/aspnetcore/configure_form_fields_required.cs
    :language: csharp

.. only:: aspnet

  .. literalinclude:: code/registration/aspnet/configure_form_fields_required.cs
    :language: csharp

.. only:: nancy

  .. .literalinclude:: code/registration/nancy/configure_form_fields_required.cs
    :language: csharp

If you would like to remove a field from the form entirely, set the ``visible`` or ``enabled`` properties to ``false``. The behavior is slightly different:

* If a field is ``visible = false`` but is still enabled, it will not be rendered on the form, but POST requests can still supply data for the field.
* If a field is ``enabled = false``, POST requests containing the field will return an error.

.. note::
  Because the Stormpath API requires a first and last name, the library will auto-fill these fields with ``UNKNOWN`` if you make them optional and the user does not provide them.


.. _register_custom_fields:

Adding custom fields
....................

You can add your own custom fields to the form.  The values will be
automatically added to the user's `Custom Data`_ object when they register
successfully.  You can create a custom field by defining a new field configuration:

.. code-block:: yaml

  web:
    register:
      form:
        fields:
          favoriteColor:
            enabled: true
            visible: true
            label: "Favorite Color"
            placeholder: "e.g. red, blue"
            required: true
            type: "text"

Or, in code:

.. only:: aspnetcore

  .. literalinclude:: code/registration/aspnetcore/configure_custom_form_field.cs
    :language: csharp

.. only:: aspnet

  .. literalinclude:: code/registration/aspnet/configure_custom_form_field.cs
    :language: csharp

.. only:: nancy

  .. .literalinclude:: code/registration/nancy/configure_custom_form_field.cs
    :language: csharp


Changing field order
....................

If you want to change the order of the fields, you can do so by specifying the
``fieldOrder`` array:

.. code-block:: yaml

  web:
    register:
      form:
        fieldOrder:
          - "surname"
          - "givenName"
          - "email"
          - "password"

Or, in code:

.. only:: aspnetcore

  .. literalinclude:: code/registration/aspnetcore/configure_field_order.cs
    :language: csharp

.. only:: aspnet

  .. literalinclude:: code/registration/aspnet/configure_field_order.cs
    :language: csharp

.. only:: nancy

  .. .literalinclude:: code/registration/nancy/configure_field_order.cs
    :language: csharp

Any visible fields that are omitted from the ``fieldOrder`` array will be placed at the end of the form.


Password strength requirements
------------------------------

Stormpath supports complex password strength rules, such as the number of letters or special characters required.  These settings are controlled on a per-Directory basis.

If you want to modify the password strength rules for your application, use the `Stormpath Admin Console`_ to find the directory that is mapped to your application, and modify the associated password policy.

For more information, see the `Account Password Strength Policy`_ section in the REST API documentation.


Email verification
------------------

We **highly** recommend that you use email verification, as it adds an additional layer of security to your site (it makes it harder for bots to create spam accounts).

Email verification will be automatically enabled if the Verification Email workflow is enabled on the Stormpath Directory linked to your application; see the :ref:`email_verification` section.


.. _auto_login:

Auto login
----------

After registering, the default behavior is to require the user to enter their new credentials to log in. If you want users to be automatically logged in after they register, use this configuration:

.. code-block:: yaml

  web:
    register:
      autoLogin: true
      nextUri: "/"

By default the ``nextUri`` is to ``/`` (the root page), but you can modify this to whatever destination you want.

.. note::
  The :ref:`email_verification` and :ref:`password_reset` features will observe this setting as well.


.. _json_registration_api:

Mobile/JSON API
---------------

If you are using this library from a mobile application, or a client framework like Angular or React, you'll interact with this endpoint via GET and POST requests.


Getting the form view model
...........................

By making a GET request to the registration endpoint with the ``Accept: application/json`` header, you can retrieve a JSON view model that describes the registration form and any external account stores that are mapped to your Stormpath Application.

Here's an example view model that represents an application that has the default registration form, and a mapped Google social directory:

.. code-block:: javascript

  {
    "accountStores": [
      {
        "name": "Google social directory",
        "href": "https://api.stormpath.com/v1/directories/gc0Ty90yXXk8ifd2QPwt",
        "provider": {
          "providerId": "google",
          "clientId": "441084632428-9au0gijbo5icagep9u79qtf7ic7cc5au.apps.googleusercontent.com",
          "scope": "email profile",
          "href": "https://api.stormpath.com/v1/directories/gc0Ty90yXXk8ifd2QPwt/provider"
        }
      }
    ],
    "form": {
      "fields": [
        {
          "label": "First Name",
          "placeholder": "First Name",
          "required": true,
          "type": "text",
          "name": "givenName"
        },
        {
          "label": "Last Name",
          "placeholder": "Last Name",
          "required": true,
          "type": "text",
          "name": "surname"
        },
        {
          "label": "Email",
          "placeholder": "Email",
          "required": true,
          "type": "email",
          "name": "email"
        },
        {
          "label": "Password",
          "placeholder": "Password",
          "required": true,
          "type": "password",
          "name": "password"
        }
      ]
    }
  }

.. tip::

  You may have to explicitly tell your client library that you want a JSON
  response from the server. Not all libraries do this automatically. If the
  library does not set the ``Accept: application/json`` header on the request,
  you'll get back the HTML registration form instead of the JSON response that you
  expect!


Registering a user
..................

Simply post a JSON object to ``/register`` and supply the fields that you wish to
populate for the user:

.. code-block:: none

    POST /register
    Accept: application/json
    Content-Type: application/json

    {
        "email": "foo@bar.com",
        "password": "mySuper3ecretPAssw0rd",
        "surname": "bar",
        "givenName": "foo"
    }

If the user is created successfully, you'll get a ``200 OK`` response. The body of the response will contain the account object that was created:

.. code-block:: json

  {
    "account": {
      "href": "https://api.stormpath.com/v1/accounts/xxx",
      "username": "foo@bar.com",
      "modifiedAt": "2016-01-26T20:50:03.931Z",
      "status": "ENABLED",
      "createdAt": "2015-10-13T20:54:22.215Z",
      "email": "foo@bar.com",
      "middleName": null,
      "surname": "bar",
      "givenName": "foo",
      "fullName": "foo bar"
    }
  }

If an error occurs, you'll get an error response:

.. code-block:: json

  {
    "status": 400,
    "message": "Invalid username or password."
  }


Supplying custom fields
.......................

If any custom fields exist on the form (see :ref:`register_custom_fields`), you can supply them either as a root property, or a child of a property called ``customData``:

.. code-block:: none

  POST /register
  Accept: application/json
  Content-Type: application/json

  {
      "email": "foo@bar.com",
      "password": "mySuper3ecretPAssw0rd",
      "surname": "bar",
      "givenName": "foo",
      "customValue": "custom value can be on root object or in customData object",
      "customData": {
        "favoriteColor": "red"
      }
  }


.. _register_default_configuration:

Default configuration
---------------------

Options that are not overridden by explicit configuration (see :ref:`configuration`) will retain their default values.

For reference, the full default configuration for this route is shown as YAML below:

.. code-block:: yaml

  web:
    register:
      enabled: true
      uri: "/register"
      autoLogin: false
      nextUri: "/"
      view: "register"
      form:
        fields:
          givenName:
            enabled: true
            visible: true
            label: "First Name"
            placeholder: "First Name"
            required: true
            type: "text"
          middleName:
            enabled: false
            visible: true
            label: "Middle Name"
            placeholder: "Middle Name"
            required: true
            type: "text"
          surname:
            enabled: true
            visible: true
            label: "Last Name"
            placeholder: "Last Name"
            required: true
            type: "text"
          username:
            enabled: false
            visible: true
            label: "Username"
            placeholder: "Username"
            required: true
            type: "text"
          email:
            enabled: true
            visible: true
            label: "Email"
            placeholder: "Email"
            required: true
            type: "email"
          password:
            enabled: true
            visible: true
            label: "Password"
            placeholder: "Password"
            required: true
            type: "password"
          confirmPassword:
            enabled: false
            visible: true
            label: "Confirm Password"
            placeholder: "Confirm Password"
            required: true
            type: "password"
        fieldOrder:
          - "username"
          - "givenName"
          - "middleName"
          - "surname"
          - "email"
          - "password"
          - "confirmPassword"

.. tip::
  You can also refer to the `Example Stormpath configuration`_ to see the entire default library configuration.


.. _Example Stormpath configuration: https://github.com/stormpath/stormpath-framework-spec/blob/master/example-config.yaml
.. _Custom Data: http://docs.stormpath.com/rest/product-guide/latest/accnt_mgmt.html#how-to-store-additional-user-information-as-custom-data
.. _pre-built view templates: https://github.com/stormpath/stormpath-dotnet-owin-middleware/tree/master/src/Stormpath.Owin.Views

.. _Stormpath Admin Console: https://api.stormpath.com
.. _Account Password Strength Policy: https://docs.stormpath.com/rest/product-guide/latest/accnt_mgmt.html#manage-password-policies
