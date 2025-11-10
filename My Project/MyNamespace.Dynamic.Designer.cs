using eLib.Forms;
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace eLib.My
{
    internal static partial class MyProject
    {
        internal partial class MyForms
        {

            [EditorBrowsable (EditorBrowsableState.Never)]
            public frmAbout m_frmAbout;

            public frmAbout frmAbout
            {
                [DebuggerHidden]
                get
                {
                    m_frmAbout = Create__Instance__ (m_frmAbout);
                    return m_frmAbout;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals (value, m_frmAbout))
                        return;
                    if (value is not null)
                        throw new ArgumentException ("Property can only be set to Nothing");
                    Dispose__Instance__ (ref m_frmAbout);
                }
            }


            [EditorBrowsable (EditorBrowsableState.Never)]
            public frmAssign m_frmAssign;

            public frmAssign frmAssign
            {
                [DebuggerHidden]
                get
                {
                    m_frmAssign = Create__Instance__ (m_frmAssign);
                    return m_frmAssign;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals (value, m_frmAssign))
                        return;
                    if (value is not null)
                        throw new ArgumentException ("Property can only be set to Nothing");
                    Dispose__Instance__ (ref m_frmAssign);
                }
            }


            [EditorBrowsable (EditorBrowsableState.Never)]
            public frmChooseProject m_frmChooseProject;

            public frmChooseProject frmChooseProject
            {
                [DebuggerHidden]
                get
                {
                    m_frmChooseProject = Create__Instance__ (m_frmChooseProject);
                    return m_frmChooseProject;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals (value, m_frmChooseProject))
                        return;
                    if (value is not null)
                        throw new ArgumentException ("Property can only be set to Nothing");
                    Dispose__Instance__ (ref m_frmChooseProject);
                }
            }


            [EditorBrowsable (EditorBrowsableState.Never)]
            public frmCNN m_frmCNN;

            public frmCNN frmCNN
            {
                [DebuggerHidden]
                get
                {
                    m_frmCNN = Create__Instance__ (m_frmCNN);
                    return m_frmCNN;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals (value, m_frmCNN))
                        return;
                    if (value is not null)
                        throw new ArgumentException ("Property can only be set to Nothing");
                    Dispose__Instance__ (ref m_frmCNN);
                }
            }


            [EditorBrowsable (EditorBrowsableState.Never)]
            public frmFolderRefs m_frmFolderRefs;

            public frmFolderRefs frmFolderRefs
            {
                [DebuggerHidden]
                get
                {
                    m_frmFolderRefs = Create__Instance__ (m_frmFolderRefs);
                    return m_frmFolderRefs;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals (value, m_frmFolderRefs))
                        return;
                    if (value is not null)
                        throw new ArgumentException ("Property can only be set to Nothing");
                    Dispose__Instance__ (ref m_frmFolderRefs);
                }
            }


            [EditorBrowsable (EditorBrowsableState.Never)]
            public frmImportRefs m_frmImportRefs;

            public frmImportRefs frmImportRefs
            {
                [DebuggerHidden]
                get
                {
                    m_frmImportRefs = Create__Instance__ (m_frmImportRefs);
                    return m_frmImportRefs;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals (value, m_frmImportRefs))
                        return;
                    if (value is not null)
                        throw new ArgumentException ("Property can only be set to Nothing");
                    Dispose__Instance__ (ref m_frmImportRefs);
                }
            }


            [EditorBrowsable (EditorBrowsableState.Never)]
            public frmNotes m_frmNotes;

            public frmNotes frmNotes
            {
                [DebuggerHidden]
                get
                {
                    m_frmNotes = Create__Instance__ (m_frmNotes);
                    return m_frmNotes;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals (value, m_frmNotes))
                        return;
                    if (value is not null)
                        throw new ArgumentException ("Property can only be set to Nothing");
                    Dispose__Instance__ (ref m_frmNotes);
                }
            }


            [EditorBrowsable (EditorBrowsableState.Never)]
            public frmProject m_frmProject;

            public frmProject frmProject
            {
                [DebuggerHidden]
                get
                {
                    m_frmProject = Create__Instance__ (m_frmProject);
                    return m_frmProject;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals (value, m_frmProject))
                        return;
                    if (value is not null)
                        throw new ArgumentException ("Property can only be set to Nothing");
                    Dispose__Instance__ (ref m_frmProject);
                }
            }


            [EditorBrowsable (EditorBrowsableState.Never)]
            public frmQR m_frmQR;

            public frmQR frmQR
            {
                [DebuggerHidden]
                get
                {
                    m_frmQR = Create__Instance__ (m_frmQR);
                    return m_frmQR;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals (value, m_frmQR))
                        return;
                    if (value is not null)
                        throw new ArgumentException ("Property can only be set to Nothing");
                    Dispose__Instance__ (ref m_frmQR);
                }
            }


            [EditorBrowsable (EditorBrowsableState.Never)]
            public frmReadRef m_frmReadRef;

            public frmReadRef frmReadRef
            {
                [DebuggerHidden]
                get
                {
                    m_frmReadRef = Create__Instance__ (m_frmReadRef);
                    return m_frmReadRef;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals (value, m_frmReadRef))
                        return;
                    if (value is not null)
                        throw new ArgumentException ("Property can only be set to Nothing");
                    Dispose__Instance__ (ref m_frmReadRef);
                }
            }


            [EditorBrowsable (EditorBrowsableState.Never)]
            public frmRefAttributes m_frmRefAttributes;

            public frmRefAttributes frmRefAttributes
            {
                [DebuggerHidden]
                get
                {
                    m_frmRefAttributes = Create__Instance__ (m_frmRefAttributes);
                    return m_frmRefAttributes;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals (value, m_frmRefAttributes))
                        return;
                    if (value is not null)
                        throw new ArgumentException ("Property can only be set to Nothing");
                    Dispose__Instance__ (ref m_frmRefAttributes);
                }
            }


            [EditorBrowsable (EditorBrowsableState.Never)]
            public frmScan m_frmScan;

            public frmScan frmScan
            {
                [DebuggerHidden]
                get
                {
                    m_frmScan = Create__Instance__ (m_frmScan);
                    return m_frmScan;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals (value, m_frmScan))
                        return;
                    if (value is not null)
                        throw new ArgumentException ("Property can only be set to Nothing");
                    Dispose__Instance__ (ref m_frmScan);
                }
            }


            [EditorBrowsable (EditorBrowsableState.Never)]
            public frmSettings m_frmSettings;

            public frmSettings frmSettings
            {
                [DebuggerHidden]
                get
                {
                    m_frmSettings = Create__Instance__ (m_frmSettings);
                    return m_frmSettings;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals (value, m_frmSettings))
                        return;
                    if (value is not null)
                        throw new ArgumentException ("Property can only be set to Nothing");
                    Dispose__Instance__ (ref m_frmSettings);
                }
            }


            [EditorBrowsable (EditorBrowsableState.Never)]
            public frmUsers m_frmUsers;

            public frmUsers frmUsers
            {
                [DebuggerHidden]
                get
                {
                    m_frmUsers = Create__Instance__ (m_frmUsers);
                    return m_frmUsers;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals (value, m_frmUsers))
                        return;
                    if (value is not null)
                        throw new ArgumentException ("Property can only be set to Nothing");
                    Dispose__Instance__ (ref m_frmUsers);
                }
            }


            //Below codes where added manually by me (msht)!
            [EditorBrowsable (EditorBrowsableState.Never)]
            public frmBackup m_frmBackup;

            public frmBackup frmBackup
                {
                [DebuggerHidden]
                get
                    {
                    m_frmBackup = Create__Instance__ (m_frmBackup);
                    return m_frmBackup;
                    }
                [DebuggerHidden]
                set
                    {
                    if (ReferenceEquals (value, m_frmBackup))
                        return;
                    if (value is not null)
                        throw new ArgumentException ("Property can only be set to Nothing");
                    Dispose__Instance__ (ref m_frmBackup);
                    }
                }

            }


        }
}