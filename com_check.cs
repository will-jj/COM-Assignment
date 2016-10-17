bool comcheck1()
{
	bool check = false;
	serialPort_Light1.DiscardInBuffer();
	serialPort_Light1.Write("d");
	System.Threading.Thread.Sleep(100);
	var read = serialPortMC.ReadExisting();
	if (read[0].ToString() == "y")
	{
		check = true;
	}
	else {
		check = false;
	}
	return check;
}

bool comcheck2()
{
	bool check = false;
	serialPort_Light2.DiscardInBuffer();
	serialPort_Light2.Write("d");
	System.Threading.Thread.Sleep(100);
	var read = serialPortMC.ReadExisting();
	if (read[0].ToString() == "y")
	{
		check = true;
	}
	else {
		check = false;
	}
	return check;
}



void getAvailablePorts()
{
	
	String[] ports = SerialPort.GetPortNames();
	bool light_1 = false;
	bool light_2 = false;
	bool test = false;
	
	foreach (string port in ports)
	{
		
		if (light_1 == false)
		{
			serialPort_Light1.PortName = port;
			try
			{
				serialPort_Light1.Open();
				
				test = comcheck1();
				if(test == true)
				{
					light_1 = true;
					continue;
				}
				else {
					serialPort_Light1.Close();
					
				}
				
				
			}
			catch (UnauthorizedAccessException)
			{
				//disp "Unuathorised Access";
			}
			
		}
		if (light_2 == false)
		{
			serialPort_Light2.PortName = port;
			try
			{
				serialPort_Light2.Open();
				
				test = comcheck2();
				if(test == true)
				{
					light_1 = true;
					continue;
				}
				else {
					serialPort_Light1.Close();
					
				}
				
				
			}
			catch (UnauthorizedAccessException)
			{
				//disp "Unuathorised Access";
			}
			
		}
	}
	}	