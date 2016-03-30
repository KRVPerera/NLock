using Neurotec.Biometrics;
using Neurotec.Biometrics.Client;
using System;

namespace NLock.NLockFile.Biometric
{
    public sealed class BiometricOperations : System.IDisposable
    {
        private static readonly NBiometricClient _biometricClient = new NBiometricClient { BiometricTypes = NBiometricType.Face, UseDeviceManager = true };
        private bool _disposed;
        public readonly static NBiometricClient BiometricClient = _biometricClient;

        private BiometricOperations()
        {
        }

        ~BiometricOperations()
        {
            Dispose();
        }

        

        public void Dispose()
        {
            if (_biometricClient != null && !_disposed)
            {
                _biometricClient.Cancel();
                _biometricClient.Dispose();
                _disposed = true;
            }

            GC.SuppressFinalize(this);
        }
    }
}