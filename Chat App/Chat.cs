using System;

public class Chat
{
	public static void Message(Student a, Teacher b)
	{
        if(b.recieveMessage(a.sendMessage()))
        {
            b.sendMessage();

        } else if(a.recieveMessage(b.sendMessage()))
        {
            a.sendMessage();

        } else if(a.recieveMessage(b.sendMessage()))
        {
            b.sendMessage();
        } else
        {
            a.sendMessage();
        }
	}
}
