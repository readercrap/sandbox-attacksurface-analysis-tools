﻿//  Copyright 2018 Google Inc. All Rights Reserved.
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

using NtApiDotNet.Ndr;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace NtApiDotNet.Win32
{
#pragma warning disable 1591
    /// <summary>
    /// Flags for DefineDosDevice
    /// </summary>
    [Flags]
    public enum DefineDosDeviceFlags
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,
        /// <summary>
        /// Specify a raw target path
        /// </summary>
        RawTargetPath = 1,
        /// <summary>
        /// Remove existing definition
        /// </summary>
        RemoveDefinition = 2,
        /// <summary>
        /// Only remove exact matches to the target
        /// </summary>
        ExactMatchOnRemove = 4,
        /// <summary>
        /// Don't broadcast changes to the system
        /// </summary>
        NoBroadcastSystem = 8,
    }

    /// <summary>
    /// Disposition values for CreateFile.
    /// </summary>
    public enum CreateFileDisposition
    {
        /// <summary>
        /// Create a new file. Fail if it exists.
        /// </summary>
        CreateNew = 1,
        /// <summary>
        /// Always create a new file, overwrite if it exists.
        /// </summary>
        CreateAlways = 2,
        /// <summary>
        /// Open a file, fail if it doesn't exist.
        /// </summary>
        OpenExisting = 3,
        /// <summary>
        /// Open a file, create if it doesn't exist.
        /// </summary>
        OpenAlways = 4,
        /// <summary>
        /// Truncate existing file.
        /// </summary>
        TruncateExisting = 5
    }

    [Flags]
    public enum CreateFileFlagsAndAttributes : uint
    {
        None = 0,
        ReadOnly = 0x00000001,
        Hidden = 0x00000002,
        System = 0x00000004,
        Directory = 0x00000010,
        Archive = 0x00000020,
        Device = 0x00000040,
        Normal = 0x00000080,
        Temporary = 0x00000100,
        SparseFile = 0x00000200,
        ReparsePoint = 0x00000400,
        Compressed = 0x00000800,
        Offline = 0x00001000,
        NotContentIndexed = 0x00002000,
        Encrypted = 0x00004000,
        IntegrityStream = 0x00008000,
        SecurityIdentification = 0x00010000,
        SecurityImpersonation = 0x00020000,
        SecurityDelegation = 0x00030000,
        ContextTracking = 0x00040000,
        EffectiveOnly = 0x00080000,
        SQoSPresent = 0x00100000,
        OpenReparsePoint = 0x00200000,
        PosixSemantics = 0x01000000,
        BackupDemantics = 0x02000000,
        DeleteOnClose = 0x04000000,
        SequentialScan = 0x08000000,
        RandomAccess = 0x10000000,
        NoBuffering = 0x20000000,
        Overlapped = 0x40000000,
        WriteThrough = 0x80000000,
    }

    internal enum WTS_CONNECTSTATE_CLASS
    {
        WTSActive,              // User logged on to WinStation
        WTSConnected,           // WinStation connected to client
        WTSConnectQuery,        // In the process of connecting to client
        WTSShadow,              // Shadowing another WinStation
        WTSDisconnected,        // WinStation logged on without client
        WTSIdle,                // Waiting for client to connect
        WTSListen,              // WinStation is listening for connection
        WTSReset,               // WinStation is being reset
        WTSDown,                // WinStation is down due to error
        WTSInit,                // WinStation in initialization
    }

    [Flags]
    internal enum SaferScope
    {
        Machine = 1,
        User = 2
    }

    [Flags]
    internal enum SaferFlags
    {
        NullIfEqual = 1,
        CompareOnly = 2,
        MakeInert = 4,
        WantFlags = 8,
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct WTS_SESSION_INFO
    {
        public int SessionId;
        public IntPtr pWinStationName;
        public WTS_CONNECTSTATE_CLASS State;
    }

    internal enum SidNameUse
    {
        SidTypeUser = 1,
        SidTypeGroup,
        SidTypeDomain,
        SidTypeAlias,
        SidTypeWellKnownGroup,
        SidTypeDeletedAccount,
        SidTypeInvalid,
        SidTypeUnknown,
        SidTypeComputer,
        SidTypeLabel
    }

    /// <summary>
    /// Flags for GetWin32PathName.
    /// </summary>
    [Flags]
    public enum Win32PathNameFlags
    {
        /// <summary>
        /// No flags.
        /// </summary>
        None = 0,
        /// <summary>
        /// GUID format.
        /// </summary>
        NameGuid = 1,
        /// <summary>
        /// NT format.
        /// </summary>
        NameNt = 2,
        /// <summary>
        /// No specific format.
        /// </summary>
        NameNone = 4,
        /// <summary>
        /// Opened file name.
        /// </summary>
        Opened = 8,
    }

    [Flags]
    internal enum FormatFlags
    {
        AllocateBuffer = 0x00000100,
        FromHModule = 0x00000800,
        FromSystem = 0x00001000,
        IgnoreInserts = 0x00000200
    }

    [Flags]
    internal enum SERVICE_STATE
    {
        SERVICE_ACTIVE = 1,
        SERVICE_INACTIVE = 2,
        SERVICE_STATE_ALL = SERVICE_ACTIVE | SERVICE_INACTIVE
    }

    [Flags]
    internal enum PackageFlags
    {
        Basic = 0,
        Full = 0x00000100
    }

    internal enum EventControlCode
    {
        DisableProvider = 0,
        EnableProvider = 1,
        CaptureState = 2,
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct PROCESS_INFORMATION
    {
        public IntPtr hProcess;
        public IntPtr hThread;
        public int dwProcessId;
        public int dwThreadId;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct PACKAGE_VERSION
    {
        public ushort Revision;
        public ushort Build;
        public ushort Minor;
        public ushort Major;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct PACKAGE_ID
    {
        public int reserved;
        public int processorArchitecture;
        public PACKAGE_VERSION version;
        public IntPtr name;
        public IntPtr publisher;
        public IntPtr resourceId;
        public IntPtr publisherId;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct EVENT_FILTER_DESCRIPTOR
    {
        public long Ptr;
        public int Size;
        public int Type;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal class ENABLE_TRACE_PARAMETERS
    {
        public int Version;
        public uint EnableProperty;
        public uint ControlFlags;
        public Guid SourceId;
        public IntPtr EnableFilterDesc; // PEVENT_FILTER_DESCRIPTOR
        public int FilterDescCount; // Only in v2 version of the parameters.
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct EVENT_DESCRIPTOR
    {
        public ushort Id;
        public byte Version;
        public byte Channel;
        public byte Level;
        public byte Opcode;
        public ushort Task;
        public ulong Keyword;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct EVENT_DATA_DESCRIPTOR
    {
        public long Ptr;
        public int Size;
        public byte Type;
        public byte Reserved1;
        public ushort Reserved2;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct WNODE_HEADER
    {
        public int BufferSize;
        public int ProviderId;
        public ulong HistoricalContext;
        public LargeIntegerStruct TimeStamp;
        public Guid Guid;
        public uint ClientContext;
        public uint Flags;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct EVENT_TRACE_PROPERTIES
    {
        public WNODE_HEADER Wnode;
        public int BufferSize;
        public int MinimumBuffers;
        public int MaximumBuffers;
        public int MaximumFileSize;
        public int LogFileMode;
        public int FlushTimer;
        public int EnableFlags;
        public int AgeLimit;
        public int NumberOfBuffers;
        public int FreeBuffers;
        public int EventsLost;
        public int BuffersWritten;
        public int LogBuffersLost;
        public int RealTimeBuffersLost;
        public IntPtr LoggerThreadId;
        public int LogFileNameOffset;
        public int LoggerNameOffset;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct TRACE_PROVIDER_INFO
    {
        public Guid ProviderGuid;
        public int SchemaSource;
        public uint ProviderNameOffset;
    }

    [StructLayout(LayoutKind.Sequential), DataStart("TraceProviderInfoArray")]
    internal struct PROVIDER_ENUMERATION_INFO
    {
        public int NumberOfProviders;
        public int Reserved;
        public TRACE_PROVIDER_INFO TraceProviderInfoArray;
    }

    internal enum TRACE_QUERY_INFO_CLASS
    {
        TraceGuidQueryList,
        TraceGuidQueryInfo,
        TraceGuidQueryProcess,
        TraceStackTracingInfo,
        TraceSystemTraceEnableFlagsInfo,
        TraceSampledProfileIntervalInfo,
        TraceProfileSourceConfigInfo,
        TraceProfileSourceListInfo,
        TracePmcEventListInfo,
        TracePmcCounterListInfo,
        TraceSetDisallowList,
        TraceVersionInfo,
        TraceGroupQueryList,
        TraceGroupQueryInfo,
        TraceDisallowListQuery,
        TraceInfoReserved15,
        TracePeriodicCaptureStateListInfo,
        TracePeriodicCaptureStateInfo,
        TraceProviderBinaryTracking,
        TraceMaxLoggersQuery,
        MaxTraceSetInfoClass,
        TraceLbrConfigurationInfo,
        TraceLbrEventListInfo,
        TraceMaxPmcCounterQuery
    }

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    internal delegate bool EnumResTypeProc(IntPtr hModule, IntPtr lpszType, IntPtr lParam);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    internal delegate bool EnumResNameProcDelegate(IntPtr hModule, IntPtr lpszType, IntPtr lpszName, IntPtr lParam);

    [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode)]
    internal delegate Win32Error GetStagedPackageOrigin(string packageFullName, out PackageOrigin origin);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    internal delegate void EventEnableCallback(
          ref Guid SourceId,
          int IsEnabled,
          byte Level,
          ulong MatchAnyKeyword,
          ulong MatchAllKeyword,
          ref EVENT_FILTER_DESCRIPTOR FilterData,
          IntPtr CallbackContext
        );

    internal static class Win32NativeMethods
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool DefineDosDevice(DefineDosDeviceFlags dwFlags, string lpDeviceName, string lpTargetPath);

        [DllImport("aclui.dll", SetLastError = true)]
        internal static extern bool EditSecurity(IntPtr hwndOwner, ISecurityInformation psi);

        [DllImport("rpcrt4.dll", CharSet = CharSet.Unicode)]
        internal static extern int RpcBindingFromStringBinding([MarshalAs(UnmanagedType.LPTStr)] string StringBinding, out SafeRpcBindingHandle Binding);

        [DllImport("rpcrt4.dll", CharSet = CharSet.Unicode)]
        internal static extern int RpcEpResolveBinding(SafeRpcBindingHandle Binding, ref RPC_SERVER_INTERFACE IfSpec);

        [DllImport("rpcrt4.dll", CharSet = CharSet.Unicode)]
        internal static extern int RpcMgmtEpEltInqBegin(
            SafeRpcBindingHandle EpBinding,
            RpcEndpointInquiryFlag InquiryType,
            RPC_IF_ID IfId,
            RpcEndPointVersionOption VersOption,
            UUID ObjectUuid,
            out SafeRpcInquiryHandle InquiryContext
        );

        [DllImport("rpcrt4.dll", CharSet = CharSet.Unicode)]
        internal static extern int RpcMgmtEpEltInqNext(
          SafeRpcInquiryHandle InquiryContext,
          [Out] RPC_IF_ID IfId,
          out SafeRpcBindingHandle Binding,
          [Out] UUID ObjectUuid,
          out SafeRpcStringHandle Annotation
        );

        [DllImport("rpcrt4.dll", CharSet = CharSet.Unicode)]
        internal static extern int RpcMgmtEpEltInqDone(
          ref IntPtr InquiryContext
        );

        [DllImport("rpcrt4.dll", CharSet = CharSet.Unicode)]
        internal static extern int RpcMgmtInqIfIds(
            SafeRpcBindingHandle Binding,
            out SafeRpcIfIdVectorHandle IfIdVector
        );

        [DllImport("rpcrt4.dll", CharSet = CharSet.Unicode)]
        internal static extern int RpcBindingFree(ref IntPtr Binding);

        [DllImport("rpcrt4.dll", CharSet = CharSet.Unicode)]
        internal static extern int RpcBindingToStringBinding(
            IntPtr Binding,
            out SafeRpcStringHandle StringBinding
        );

        [DllImport("rpcrt4.dll", CharSet = CharSet.Unicode)]
        internal static extern int RpcStringBindingParse(
              string StringBinding,
              out SafeRpcStringHandle ObjUuid,
              out SafeRpcStringHandle Protseq,
              out SafeRpcStringHandle NetworkAddr,
              out SafeRpcStringHandle Endpoint,
              out SafeRpcStringHandle NetworkOptions
            );

        [DllImport("rpcrt4.dll", CharSet = CharSet.Unicode)]
        internal static extern int RpcStringBindingCompose(
          string ObjUuid,
          string ProtSeq,
          string NetworkAddr,
          string Endpoint,
          string Options,
          out SafeRpcStringHandle StringBinding
        );

        [DllImport("rpcrt4.dll", CharSet = CharSet.Unicode)]
        internal static extern int RpcStringFree(
            ref IntPtr String
        );

        [DllImport("rpcrt4.dll", CharSet = CharSet.Unicode)]
        internal static extern int RpcIfIdVectorFree(
            ref IntPtr IfIdVector
        );

        [DllImport("rpcrt4.dll")]
        internal static extern void I_RpcFree(IntPtr pObject);

        [DllImport("rpcrt4.dll")]
        internal static extern Win32Error I_RpcGetDefaultSD(out IntPtr ppSecurityDescriptor);

        [DllImport("shell32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern SafeLocalAllocBuffer CommandLineToArgvW(string lpCmdLine, out int pNumArgs);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern SafeLoadLibraryHandle LoadLibraryEx(string name, IntPtr reserved, LoadLibraryFlags flags);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool FreeLibrary(IntPtr hModule);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        internal static extern IntPtr GetProcAddress(IntPtr hModule, string name);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern int GetModuleFileName(IntPtr hModule, [Out] StringBuilder lpFilename, int nSize);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr GetProcAddress(IntPtr hModule, IntPtr name);

        [DllImport("dbghelp.dll", SetLastError = true)]
        internal static extern IntPtr ImageDirectoryEntryToData(IntPtr Base, bool MappedAsImage, ushort DirectoryEntry, out int Size);

        [DllImport("dbghelp.dll", SetLastError = true)]
        internal static extern IntPtr ImageNtHeader(
            IntPtr Base
        );

        internal const int GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS = 0x00000004;
        internal const int GET_MODULE_HANDLE_EX_FLAG_PIN = 0x00000001;
        internal const int GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT = 0x00000002;

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool GetModuleHandleEx(int dwFlags, IntPtr lpModuleName, out SafeLoadLibraryHandle phModule);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true, EntryPoint = "GetModuleHandleExW")]
        internal static extern bool GetModuleHandleEx(int dwFlags, string lpModuleName, out SafeLoadLibraryHandle phModule);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool GetClipboardAccessToken(out SafeKernelObjectHandle handle, TokenAccessRights desired_access);

        internal const int SAFER_LEVEL_OPEN = 1;

        [DllImport("advapi32.dll", SetLastError = true)]
        internal static extern bool SaferCreateLevel(SaferScope dwScopeId, SaferLevel dwLevelId, int OpenFlags, out IntPtr pLevelHandle, IntPtr lpReserved);

        [DllImport("advapi32.dll", SetLastError = true)]
        internal static extern bool SaferCloseLevel(IntPtr hLevelHandle);

        [DllImport("advapi32.dll", SetLastError = true)]
        internal static extern bool SaferComputeTokenFromLevel(IntPtr LevelHandle, SafeHandle InAccessToken,
            out SafeKernelObjectHandle OutAccessToken, SaferFlags dwFlags, IntPtr lpReserved);

        [DllImport("userenv.dll", CharSet = CharSet.Unicode)]
        internal static extern int DeriveAppContainerSidFromAppContainerName(
            string pszAppContainerName,
            out SafeSidBufferHandle ppsidAppContainerSid
        );

        [DllImport("userenv.dll", CharSet = CharSet.Unicode)]
        internal static extern int DeriveRestrictedAppContainerSidFromAppContainerSidAndRestrictedName(
            SafeSidBufferHandle psidAppContainerSid,
            string pszRestrictedAppContainerName,
            out SafeSidBufferHandle ppsidRestrictedAppContainerSid
        );

        [DllImport("wtsapi32.dll", SetLastError = true)]
        internal static extern bool WTSEnumerateSessions(
                IntPtr hServer,
                int Reserved,
                int Version,
                out IntPtr ppSessionInfo,
                out int pCount);

        [DllImport("wtsapi32.dll", SetLastError = true)]
        internal static extern bool WTSQueryUserToken(int SessionId, out SafeKernelObjectHandle phToken);

        [DllImport("wtsapi32.dll", SetLastError = true)]
        internal static extern void WTSFreeMemory(IntPtr memory);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern int GetFinalPathNameByHandle(SafeKernelObjectHandle hFile, StringBuilder lpszFilePath,
            int cchFilePath, Win32PathNameFlags dwFlags);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern int FormatMessage(
          FormatFlags dwFlags,
          IntPtr lpSource,
          uint dwMessageId,
          int dwLanguageId,
          out SafeLocalAllocBuffer lpBuffer,
          int nSize,
          IntPtr Arguments
        );

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool ConvertSecurityDescriptorToStringSecurityDescriptor(
            SafeBuffer SecurityDescriptor,
            int RequestedStringSDRevision,
            SecurityInformation SecurityInformation,
            out SafeLocalAllocBuffer StringSecurityDescriptor,
            out int StringSecurityDescriptorLen);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool ConvertStringSecurityDescriptorToSecurityDescriptor(
            string StringSecurityDescriptor,
            int StringSDRevision,
            out SafeLocalAllocBuffer SecurityDescriptor,
            out int SecurityDescriptorSize);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool ConvertStringSidToSid(
            string StringSid,
            out SafeLocalAllocBuffer Sid);

        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool LookupAccountSid(string lpSystemName, SafeSidBufferHandle lpSid, StringBuilder lpName,
               ref int cchName, StringBuilder lpReferencedDomainName, ref int cchReferencedDomainName, out SidNameUse peUse);

        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool LookupAccountName(string lpSystemName, string lpAccountName,
            SafeBuffer Sid,
            ref int cbSid,
            SafeBuffer ReferencedDomainName,
            ref int cchReferencedDomainName,
            out SidNameUse peUse
        );

        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool LookupPrivilegeName(
           string lpSystemName,
           ref Luid lpLuid,
           [Out] StringBuilder lpName,
           ref int cchName);

        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool LookupPrivilegeDisplayName(
          string lpSystemName,
          string lpName,
          StringBuilder lpDisplayName,
          ref int cchDisplayName,
          out int lpLanguageId
        );

        // Don't think there's a direct NT equivalent as this talks to LSASS.
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool LookupPrivilegeValue(
          string lpSystemName,
          string lpName,
          out Luid lpLuid
        );

        [DllImport("kernel32.dll")]
        internal static extern IntPtr LocalAlloc(int flags, IntPtr size);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr LocalFree(IntPtr hMem);

        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        internal static extern bool EnumResourceTypes(IntPtr hModule, EnumResTypeProc lpEnumFunc, IntPtr lParam);

        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        internal static extern bool EnumResourceNames(SafeLoadLibraryHandle hModule, IntPtr lpszType,
            EnumResNameProcDelegate lpEnumFunc, IntPtr lParam);

        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        internal static extern IntPtr LoadResource(SafeLoadLibraryHandle hModule, IntPtr hResInfo);

        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        internal static extern IntPtr LockResource(IntPtr hResData);

        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        internal static extern int SizeofResource(SafeLoadLibraryHandle hModule, IntPtr hResInfo);

        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        internal static extern IntPtr FindResource(SafeLoadLibraryHandle hModule, IntPtr lpName, IntPtr lpType);

        [DllImport("Secur32.dll")]
        internal static extern NtStatus LsaConnectUntrusted(out SafeLsaHandle handle);

        [DllImport("Secur32.dll")]
        internal static extern NtStatus LsaLookupAuthenticationPackage(SafeLsaHandle LsaHandle, LsaString PackageName, out uint AuthenticationPackage);

        [DllImport("Secur32.dll")]
        internal static extern NtStatus LsaLogonUser(SafeLsaHandle LsaHandle, LsaString OriginName, SecurityLogonType LogonType, uint AuthenticationPackage,
            SafeBuffer AuthenticationInformation,
            int AuthenticationInformationLength,
            IntPtr LocalGroups,
            TOKEN_SOURCE SourceContext,
            out IntPtr ProfileBuffer,
            out int ProfileBufferLength,
            out Luid LogonId,
            out SafeKernelObjectHandle Token,
            QUOTA_LIMITS Quotas,
            out NtStatus SubStatus
        );

        [DllImport("Secur32.dll")]
        internal static extern NtStatus LsaFreeReturnBuffer(IntPtr Buffer);

        [DllImport("Advapi32.dll")]
        internal static extern bool AllocateLocallyUniqueId(out Luid Luid);

        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, SecurityLogonType dwLogonType,
            int dwLogonProvider, out SafeKernelObjectHandle phToken);

        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool LogonUserExExW(
              string lpszUsername,
              string lpszDomain,
              string lpszPassword,
              SecurityLogonType dwLogonType,
              int dwLogonProvider,
              SafeTokenGroupsBuffer pTokenGroups,
              out SafeKernelObjectHandle phToken,
              [Out] OptionalPointer ppLogonSid,
              [Out] OptionalPointer ppProfileBuffer,
              [Out] OptionalPointer pdwProfileLength,
              [Out] QUOTA_LIMITS pQuotaLimits
            );

        [DllImport("Advapi32.dll")]
        internal static extern NtStatus LsaClose(IntPtr handle);

        [DllImport("Advapi32.dll", SetLastError = true)]
        internal static extern bool CloseServiceHandle(IntPtr hSCObject);

        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern SafeServiceHandle OpenSCManager(string lpMachineName, string lpDatabaseName, ServiceControlManagerAccessRights dwDesiredAccess);

        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern SafeServiceHandle OpenService(
              SafeServiceHandle hSCManager,
              string lpServiceName,
              ServiceAccessRights dwDesiredAccess
            );

        [DllImport("Advapi32.dll", SetLastError = true)]
        internal static extern bool QueryServiceObjectSecurity(SafeServiceHandle hService,
            SecurityInformation dwSecurityInformation,
            [Out] byte[] lpSecurityDescriptor,
            int cbBufSize,
            out int pcbBytesNeeded);

        [DllImport("Advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool QueryServiceConfig(
          SafeServiceHandle hService,
          SafeBuffer lpServiceConfig,
          int cbBufSize,
          out int pcbBytesNeeded
        );

        [DllImport("Advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool QueryServiceConfig2(
          SafeServiceHandle hService,
          int dwInfoLevel,
          SafeBuffer lpBuffer,
          int cbBufSize,
          out int pcbBytesNeeded
        );

        [DllImport("Advapi32.dll", SetLastError = true)]
        internal static extern bool QueryServiceStatusEx(
          SafeServiceHandle hService,
          SC_STATUS_TYPE InfoLevel,
          SafeBuffer lpBuffer,
          int cbBufSize,
          out int pcbBytesNeeded
        );

        [DllImport("Advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool EnumServicesStatusEx(
              SafeServiceHandle hSCManager,
              SC_ENUM_TYPE InfoLevel,
              ServiceType dwServiceType,
              SERVICE_STATE dwServiceState,
              SafeHGlobalBuffer lpServices,
              int cbBufSize,
              out int pcbBytesNeeded,
              out int lpServicesReturned,
              ref int lpResumeHandle,
              string pszGroupName
            );

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool InitializeProcThreadAttributeList(
            IntPtr lpAttributeList,
            int dwAttributeCount,
            int dwFlags,
            ref IntPtr lpSize
        );

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool UpdateProcThreadAttribute(
            IntPtr lpAttributeList,
            int dwFlags,
            IntPtr Attribute,
            IntPtr lpValue,
            IntPtr cbSize,
            IntPtr lpPreviousValue,
            IntPtr lpReturnSize
        );

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool DeleteProcThreadAttributeList(
            IntPtr lpAttributeList
        );

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool CreateProcessAsUser(
          SafeKernelObjectHandle hToken,
          string lpApplicationName,
          string lpCommandLine,
          SECURITY_ATTRIBUTES lpProcessAttributes,
          SECURITY_ATTRIBUTES lpThreadAttributes,
          bool bInheritHandles,
          CreateProcessFlags dwCreationFlags,
          byte[] lpEnvironment,
          string lpCurrentDirectory,
          [In] STARTUPINFOEX lpStartupInfo,
          out PROCESS_INFORMATION lpProcessInformation);

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool CreateProcessWithTokenW(
          SafeKernelObjectHandle hToken,
          CreateProcessLogonFlags dwLogonFlags,
          string lpApplicationName,
          string lpCommandLine,
          CreateProcessFlags dwCreationFlags,
          [In] byte[] lpEnvironment,
          string lpCurrentDirectory,
          ref STARTUPINFO lpStartupInfo,
          out PROCESS_INFORMATION lpProcessInformation);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool CreateProcess(
          string lpApplicationName,
          string lpCommandLine,
          [In] SECURITY_ATTRIBUTES lpProcessAttributes,
          [In] SECURITY_ATTRIBUTES lpThreadAttributes,
          bool bInheritHandles,
          CreateProcessFlags dwCreationFlags,
          [In] byte[] lpEnvironment,
          string lpCurrentDirectory,
          [In] STARTUPINFOEX lpStartupInfo,
          out PROCESS_INFORMATION lpProcessInformation);

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool CreateProcessWithLogonW(
          string lpUsername,
          string lpDomain,
          string lpPassword,
          CreateProcessLogonFlags dwLogonFlags,
          string lpApplicationName,
          string lpCommandLine,
          CreateProcessFlags dwCreationFlags,
          [In] byte[] lpEnvironment,
          string lpCurrentDirectory,
          ref STARTUPINFO lpStartupInfo,
          out PROCESS_INFORMATION lpProcessInformation);

        [DllImport("userenv.dll", CharSet = CharSet.Unicode)]
        internal static extern NtStatus CreateAppContainerProfile(
          string pszAppContainerName,
          string pszDisplayName,
          string pszDescription,
          SidAndAttributes[] pCapabilities,
          int dwCapabilityCount,
          out SafeSidBufferHandle ppSidAppContainerSid
        );

        [DllImport("userenv.dll", CharSet = CharSet.Unicode)]
        internal static extern NtStatus DeleteAppContainerProfile(
            string pszAppContainerName
        );

        [DllImport("userenv.dll", CharSet = CharSet.Unicode)]
        internal static extern NtStatus GetAppContainerFolderPath(
          string pszAppContainerSid,
          out SafeCoTaskMemHandle ppszPath
        );

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        internal static extern Win32Error PackageIdFromFullName(
          string packageFullName,
          PackageFlags flags,
          ref int  bufferLength,
          SafeBuffer buffer
        );

        [DllImport("kernelbase.dll", CharSet = CharSet.Unicode)]
        internal static extern Win32Error GetStagedPackageOrigin(
          string packageFullName,
          out PackageOrigin origin
        );

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        internal static extern Win32Error GetStagedPackagePathByFullName(
            string packageFullName,
            ref int pathLength,
            StringBuilder path
        );

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode)]
        internal static extern Win32Error EventAccessQuery(
          ref Guid Guid,
          SafeBuffer Buffer,
          ref int BufferSize
        );

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode)]
        internal static extern Win32Error EventRegister(
          ref Guid ProviderId,
          EventEnableCallback EnableCallback,
          IntPtr CallbackContext,
          out long RegHandle
        );

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode)]
        internal static extern Win32Error EventUnregister(
            long RegHandle
        );

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode)]
        internal static extern Win32Error EventWrite(
          long RegHandle,
          ref EVENT_DESCRIPTOR EventDescriptor,
          int UserDataCount,
          EVENT_DATA_DESCRIPTOR[] UserData
        );

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode)]
        internal static extern Win32Error EnumerateTraceGuidsEx(
            TRACE_QUERY_INFO_CLASS TraceQueryInfoClass,
            SafeBuffer InBuffer,
            int InBufferSize,
            SafeBuffer OutBuffer,
            int OutBufferSize,
            out int ReturnLength
        );

        [DllImport("tdh.dll", CharSet = CharSet.Unicode)]
        internal static extern Win32Error TdhEnumerateProviders(
                SafeBuffer pBuffer,
                ref int pBufferSize
        );

        [DllImport("advap32.dll", CharSet = CharSet.Unicode)]
        internal static extern Win32Error StartTrace(
            out long SessionHandle,
            out string SessionName,
            SafeBuffer Properties // EVENT_TRACE_PROPERTIES
        );

        [DllImport("advap32.dll", CharSet = CharSet.Unicode)]
        internal static extern Win32Error EnableTraceEx2(
          long TraceHandle,
          ref Guid ProviderId,
          EventControlCode ControlCode,
          EventTraceLevel Level,
          ulong MatchAnyKeyword,
          ulong MatchAllKeyword,
          int   Timeout,
          ENABLE_TRACE_PARAMETERS EnableParameters
        );

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern SafeKernelObjectHandle CreateFile(
          string lpFileName,
          FileAccessRights dwDesiredAccess,
          FileShareMode dwShareMode,
          SECURITY_ATTRIBUTES lpSecurityAttributes,
          CreateFileDisposition dwCreationDisposition,
          CreateFileFlagsAndAttributes dwFlagsAndAttributes,
          SafeKernelObjectHandle hTemplateFile
        );

        [DllImport("kernelbase.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool CreateAppContainerToken(
                SafeKernelObjectHandle TokenHandle,
                ref SECURITY_CAPABILITIES SecurityCapabilities,
                out SafeKernelObjectHandle AppContainerTokenHandle);
    }
#pragma warning restore 1591
}
