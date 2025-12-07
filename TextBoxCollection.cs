using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnionField.ControlCollections
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    [ProvideProperty("Index", typeof(TextBox))]
    public class TextBoxCollection : BaseControlCollection<TextBox>
    {
    }
}
