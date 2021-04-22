using System;
using System.Collections.Generic;
using System.Text;

namespace PactoTrace
{
    internal class ExecutionContext
    {
        //work with this
        //https://github.com/serilog/serilog/issues/1015
        //and this
        //https://www.initpals.com/net-core/scoped-logging-using-microsoft-logger-with-serilog-in-net-core-application/

        //good starting point for configuring the whole thing
        //https://www.humankode.com/asp-net-core/logging-with-elasticsearch-kibana-asp-net-core-and-docker
        //set up ELK with docker
        // https://www.faciletechnolab.com/blog/2020/2/27/easiest-way-to-setup-elasticsearch-development-environment-with-docker-on-windows


        //one of the ways to add correlation id, 
        //https://letienthanh0212.medium.com/building-logging-system-in-microservice-architecture-with-elk-stack-and-serilog-net-core-part-2-2643dbbf3c2c
        //however better is with middleware and with added data within scope as as in downloaded sample scoped.logging.serilog mixed with pacto trace scope concept
        //https://github.com/alfusinigoj/scoped_logging_with_serilog

        //logging scope semantics
        //https://nblumhardt.com/2016/11/ilogger-beginscope/
        //old way of extending the data with serilog https://andrewlock.net/using-serilog-aspnetcore-in-asp-net-core-3-logging-mvc-propertis-with-serilog/
        // to check https://nblumhardt.com/2019/10/serilog-mvc-logging/

        //create the right metrics 
        //https://www.youtube.com/watch?v=xFlzPpQgXUM
        //https://aevitas.medium.com/expose-asp-net-core-metrics-with-prometheus-15e3356415f4

        //working with app metrics
        //https://github.com/AppMetrics/Samples.V2/blob/main/AspNetCore2.Api.QuickStart/MetricsRegistry.cs

        //for later use
        //https://www.devground.co/blog/posts/serilog-sending-logs-to-logstash/
        //serilog good practices
        //https://benfoster.io/blog/serilog-best-practices/#enrich-from-global-properties

    }
}
