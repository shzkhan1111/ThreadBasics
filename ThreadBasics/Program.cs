/*
 * reader and writer lock 
 * 
 * when a thread aqquires lock only that thread has access to the shared resource in the critical section 
 * in some cases we require multiple threads to read 
 * 
 * 1 or many reader thread aquire lock -> Writer cannot do anything 
 * 
 * when writer holder lock anythread cannot access the shared resource anymore 
 * 
 * Example SQL 
 * Select statement     shared lock applied to area of the table (e.g rows, pages)
 * Update and deleted -> exclusive locks 
 * 
 *  
 * 
 */

public class GlobalConfigurationCache
{
    private ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
    private Dictionary<int, string> _cache = new Dictionary<int, string>();

    public void Add(int key , string val)
    {
        //these operation are not atomic
        //broken into different parts when compiler compiles the code 
        //_cache[key] = val;
        

        bool isLockAquired = false;//incase of exception when aquiring lock
        try
        {
            _lock.EnterWriteLock();
            isLockAquired = true;
            _cache[key] = val;
        }
        finally 
        {
            if (isLockAquired)
            {
                isLockAquired = false;
                _lock.EnterWriteLock();
            }
            
        }

    }

    public string Get(int key)
    {
        //these operation are not atomic

        //return _cache.TryGetValue(key , out var value) ? value : string.Empty;
        bool isLockAquired = false;//incase of exception when aquiring lock

        try
        {
            _lock.EnterWriteLock();
            isLockAquired = true;

            return _cache.TryGetValue(key, out var value) ? value : string.Empty;

        }
        finally
        {
            if (isLockAquired)
            {
                isLockAquired = false;
                _lock.ExitWriteLock();
            }
        }
    }

}

 