// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/protobuf.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981
#region Designer generated code

using grpc = global::Grpc.Core;

namespace LoanAPI.Protos {
  public static partial class LoanService
  {
    static readonly string __ServiceName = "LoanService";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::LoanAPI.Protos.RequestLoan> __Marshaller_RequestLoan = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::LoanAPI.Protos.RequestLoan.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::LoanAPI.Protos.ResponseLoan> __Marshaller_ResponseLoan = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::LoanAPI.Protos.ResponseLoan.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::LoanAPI.Protos.Req> __Marshaller_Req = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::LoanAPI.Protos.Req.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::LoanAPI.Protos.Res> __Marshaller_Res = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::LoanAPI.Protos.Res.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::LoanAPI.Protos.RequestLoan, global::LoanAPI.Protos.ResponseLoan> __Method_ChangeStatusLoan = new grpc::Method<global::LoanAPI.Protos.RequestLoan, global::LoanAPI.Protos.ResponseLoan>(
        grpc::MethodType.Unary,
        __ServiceName,
        "ChangeStatusLoan",
        __Marshaller_RequestLoan,
        __Marshaller_ResponseLoan);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::LoanAPI.Protos.Req, global::LoanAPI.Protos.Res> __Method_Test = new grpc::Method<global::LoanAPI.Protos.Req, global::LoanAPI.Protos.Res>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Test",
        __Marshaller_Req,
        __Marshaller_Res);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::LoanAPI.Protos.ProtobufReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of LoanService</summary>
    [grpc::BindServiceMethod(typeof(LoanService), "BindService")]
    public abstract partial class LoanServiceBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::LoanAPI.Protos.ResponseLoan> ChangeStatusLoan(global::LoanAPI.Protos.RequestLoan request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::LoanAPI.Protos.Res> Test(global::LoanAPI.Protos.Req request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(LoanServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_ChangeStatusLoan, serviceImpl.ChangeStatusLoan)
          .AddMethod(__Method_Test, serviceImpl.Test).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, LoanServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_ChangeStatusLoan, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::LoanAPI.Protos.RequestLoan, global::LoanAPI.Protos.ResponseLoan>(serviceImpl.ChangeStatusLoan));
      serviceBinder.AddMethod(__Method_Test, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::LoanAPI.Protos.Req, global::LoanAPI.Protos.Res>(serviceImpl.Test));
    }

  }
}
#endregion
