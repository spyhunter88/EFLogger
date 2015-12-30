﻿namespace FrameLog.Translation.Serializers
{
    public interface ISerializationManager
    {
        /// <summary>
        /// Convert the object in to a serialized string
        /// </summary>
        /// <param name="obj">The value to be serialized</param>
        /// <returns>The serizlied value, as a string</returns>
        string Serialize(object obj);
    }
}
