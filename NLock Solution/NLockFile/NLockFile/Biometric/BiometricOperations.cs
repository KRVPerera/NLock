using Neurotec.Biometrics;
using Neurotec.Biometrics.Client;
using System;

namespace NLock.NLockFile.Biometric
{
    public sealed class BiometricOperations : System.IDisposable
    {
        private static readonly NBiometricClient _biometricClient = new NBiometricClient { BiometricTypes = NBiometricType.Face, UseDeviceManager = true };
        private bool disposed;
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
            if (_biometricClient != null && !disposed)
            {
                _biometricClient.Cancel();
                _biometricClient.Dispose();
                disposed = true;
            }

            GC.SuppressFinalize(this);
        }
    }
}