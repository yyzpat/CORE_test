﻿using CORE_test.Contracts;
using NLog;
using System;


namespace CORE_test.Services
{
  public class LoggerService : ILoggerService
  {
    private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

    public void LogDebug(string message)
    {
      logger.Debug(message);
    }

    public void LogError(string message)
    {
      logger.Error(message);
    }

    public void LogInfo(string message)
    {
      logger.Info(message);
    }

    public void LogWarn(string message)
    {
      logger.Warn(message);
    }
  }
}
