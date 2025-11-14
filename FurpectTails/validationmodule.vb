Module validationmodule

    ' ---------------- CLIENT VALIDATION ----------------
    Public Function ValidateClientInputs(lastnametxt As TextBox,
                                         firstnametxt As TextBox,
                                         midnametxt As TextBox,
                                         addresstxt As TextBox,
                                         numbertxt As TextBox,
                                         clientgendercmb As ComboBox) As Boolean

        If String.IsNullOrWhiteSpace(lastnametxt.Text) Then
            MessageBox.Show("Please enter the client's last name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            lastnametxt.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(firstnametxt.Text) Then
            MessageBox.Show("Please enter the client's first name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            firstnametxt.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(midnametxt.Text) Then
            MessageBox.Show("Please enter the client's middle name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            midnametxt.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(addresstxt.Text) Then
            MessageBox.Show("Please enter the client's address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            addresstxt.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(numbertxt.Text) Then
            MessageBox.Show("Please enter the client's phone number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            numbertxt.Focus()
            Return False
        End If

        If Not IsNumeric(numbertxt.Text) OrElse numbertxt.Text.Length < 10 OrElse numbertxt.Text.Length > 13 Then
            MessageBox.Show("Please enter a valid phone number (10–13 digits).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            numbertxt.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(clientgendercmb.Text) Then
            MessageBox.Show("Please select the client's gender.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            clientgendercmb.Focus()
            Return False
        End If

        Return True
    End Function


    ' ---------------- PET VALIDATION ----------------
    Public Function ValidatePetInputs(petnametxt As TextBox, petbreedtxt As TextBox, petagetxt As TextBox,
                                  speciescmb As ComboBox, petgendercmb As ComboBox, clientownercmb As ComboBox) As Boolean
        If String.IsNullOrWhiteSpace(petnametxt.Text) OrElse
           String.IsNullOrWhiteSpace(petbreedtxt.Text) OrElse
           String.IsNullOrWhiteSpace(petagetxt.Text) OrElse
           speciescmb.SelectedIndex = -1 OrElse
           petgendercmb.SelectedIndex = -1 OrElse
           clientownercmb.SelectedIndex = -1 Then

            MessageBox.Show("Please fill out all pet information and select a client owner.", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function


End Module
