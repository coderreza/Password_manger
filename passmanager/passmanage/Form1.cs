using System.ComponentModel;
using System.IO;

namespace passmanage;

public partial class Form1 : Form
{
    
    public Button Passaddbtn;
    public TextBox newpass;
    public Button copyButton;
    public Label Pass;
    public Label passwords;
    public Label titleLabel;  // New label
    public Button topButton;  // New button
    public string data;
    public char[] keyboardChars = {
            // Letters - Uppercase
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
            'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            
            // Letters - Lowercase
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
            'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            
            // Numbers
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            
            // Special characters (Shift + numbers)
            '!', '@', '#', '$', '%', '^', '&', '*', '(', ')',
            '_', '+', '{', '}', '|', ':', '"', '<', '>', '?',
            
            // Other special characters
            '~', '`', '-', '=', '[', ']', '\\', ';', '\'', ',', '.', '/',
            
            // Space
            ' '
        };
    public Form1()
    {
        InitializeComponent();
        copyButton = new Button(); 
        Passaddbtn = new Button();
        newpass = new TextBox();
        Pass = new Label();
        passwords = new Label();
        titleLabel = new Label();    // Initialize new label
        topButton = new Button(); 
        
        // Copy Button - placed at the top right
        copyButton.Text = "Copy";
        copyButton.Location = new Point(345, 10);  // Moved to the right
        copyButton.Size = new Size(40, 30);
        copyButton.Click += CopyButton_Click;
        
        // New Label at top
        titleLabel.Text = "new password";
        titleLabel.Font = new Font("Arial", 5, FontStyle.Bold);
        titleLabel.Location = new Point(20, 10);
        titleLabel.Size = new Size(200, 30);
        
        // New Button at top
        topButton.Text = "new password";
        topButton.Location = new Point(230, 10);
        topButton.Size = new Size(110, 30);
        
        // Set properties for each control
        // Label: "Pass"
        Pass.Text = "Enter Password:";
        Pass.Location = new Point(20, 60);
        Pass.Size = new Size(100, 20);
        
        // TextBox: newpass
        newpass.Location = new Point(130, 58);
        newpass.Size = new Size(150, 20);
        
        // Button: Passaddbtn
        Passaddbtn.Text = "Add Password";
        Passaddbtn.Location = new Point(130, 90);
        Passaddbtn.Size = new Size(150, 30);
        
        // Label: passwords (to display saved passwords)
        passwords.Text = "Saved Passwords:";
        passwords.Location = new Point(20, 140);
        passwords.Size = new Size(300, 200);
        passwords.AutoSize = false;
        
        Passaddbtn.Click += Passaddbtn_Click;
        topButton.Click += TopButton_Click;  // Add click event for new button
        
        this.Controls.Add(Passaddbtn);
        this.Controls.Add(newpass);
        this.Controls.Add(Pass);
        this.Controls.Add(passwords);
        this.Controls.Add(titleLabel);  // Add new label
        this.Controls.Add(topButton);   // Add new button
        this.Controls.Add(copyButton);  // Add copy button
        
        // Optional: Set form properties
        this.Text = "Password Manager";
        this.Size = new Size(400, 420);
        
        // Load existing passwords when form loads
        if (File.Exists("passwords.txt"))
        {
            passwords.Text = "Saved Passwords:\n" + File.ReadAllText("passwords.txt");
        }
    }
    
    private void Passaddbtn_Click(object sender, EventArgs e)
    {
        string newpas = newpass.Text.Trim();
        
        // Don't add empty passwords
        if (string.IsNullOrEmpty(newpas))
        {
            MessageBox.Show("Please enter a password.", "Warning", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        // Check if file exists, if not create it
        if (!File.Exists("passwords.txt"))
        {
            File.Create("passwords.txt").Close();
        }
        
        // Read existing content
        string existingContent = File.ReadAllText("passwords.txt");
        
        // Write the new content (existing + new password on new line)
        File.WriteAllText("passwords.txt", existingContent + newpas + Environment.NewLine);
        
        // Display the saved passwords
        passwords.Text = "Saved Passwords:\n" + File.ReadAllText("passwords.txt");
        
        // Clear the textbox
        newpass.Clear();
    }
    
    private void TopButton_Click(object sender, EventArgs e)
    {
        titleLabel.Text = "";
        for (int i = 0; i <= 16; i++)
        {
            
            char[] characters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };

// Create a Random object
            Random random = new Random();

            // Pick a random character
            char randomChar = keyboardChars[random.Next(keyboardChars.Length)];
            titleLabel.Text += randomChar;
            

        };
    }
    private void CopyButton_Click(object sender, EventArgs e)
    {
        Clipboard.SetText(titleLabel.Text);
    }
}