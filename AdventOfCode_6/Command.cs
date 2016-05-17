using System;

public class Command
{
    private String command = "";
    private int x_start = 0;
    private int y_start = 0;
    private int x_end = 0;
    private int y_end = 0;

	public Command(String command, int x_start, int y_start, int x_end, int y_end)
	{
        this.command = command;
        this.x_start = x_start;
        this.y_start = y_start;
        this.x_end = x_end;
        this.y_end = y_end;
	}

    public String getCommand() { return command; }
    public int getXstart() { return x_start; }
    public int getYstart() { return y_start; }
    public int getXend() { return x_end; }
    public int getYend() { return y_end; }
}
