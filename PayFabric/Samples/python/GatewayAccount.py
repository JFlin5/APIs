# =====================================================================
#  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
#  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
#  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
#  PARTICULAR PURPOSE.
# =====================================================================

import requests
from Token import Token


class GatewayAccount:
    """This sample is to demo how to retrieve a gateway account profile or
        to get all gateway account profile within one PayFabric account"""

    def Retrieve(self, gatewayAccountId):
        """ Retrieve a gateway account profile. Gateway account guid is generated by PayFabric,
            And 3rd party application may not keep this unique identifier. However developers can
            still retrieve these unique identifiers by get all gateway account profiles by customer.

            Keywords:
                gatewayAccountId - GUID of gateway account profile
        """

        r = requests.get(url='https://sandbox.payfabric.com/payment/api/setupid/' + gatewayAccountId,
                         headers={
                             'Content-Type': 'application/json; charset=utf-8',
                             'authorization': Token().Create()
                         })

        #
        # Sample response
        # ------------------------------------------------------
        # Response text is a gateway account object with json format
        # Go to https://github.com/PayFabric/APIs/blob/master/PayFabric/Sections/Objects.md#gateway-account-profile
        # for more details about gateway account object.
        # ------------------------------------------------------
        #
        return r.json()


    def RetrieveAll(self):
        """ Retrieve all active gateway account profiles """

        r = requests.get(url='https://sandbox.payfabric.com/payment/api/setupid',
                         headers={
                             'Content-Type': 'application/json; charset=utf-8',
                             'authorization': Token().Create()
                         })

        print r.status_code, r.text

        #
        # Sample response
        # ------------------------------------------------------
        # Response text is an array of gateway account object with json format
        # Go to https://github.com/PayFabric/APIs/blob/master/PayFabric/Sections/Objects.md#gateway-account-profile
        # for more details about gateway account object.
        # ------------------------------------------------------
        #
        return r.json()
