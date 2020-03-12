﻿using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class TapAndCheckAsyncLeftTests : BindTestsBase
    {
        [Fact]
        public void TapAndCheck_AsyncLeft_returns_failure_and_does_not_execute_func()
        {
            Task<Result> input = Result.Failure(ErrorMessage).AsCompletedTask();

            Result output = input.TapAndCheck(GetResult).Result;

            AssertFailure(output);
        }

        [Fact]
        public void TapAndCheck_AsyncLeft_selects_new_result()
        {
            Task<Result> input = Result.Success().AsCompletedTask();

            Result output = input.TapAndCheck(GetResult).Result;

            AssertSuccess(output);
        }

        [Fact]
        public void TapAndCheck_T_AsyncLeft_returns_failure_and_does_not_execute_func()
        {
            Task<Result<T>> input = Result.Failure<T>(ErrorMessage).AsCompletedTask();

            Result output = input.TapAndCheck(GetResult_WithParam).Result;

            AssertFailure(output);
        }

        [Fact]
        public void TapAndCheck_T_AsyncLeft_selects_new_result()
        {
            Task<Result<T>> input = Result.Success(T.Value).AsCompletedTask();

            Result output = input.TapAndCheck(GetResult_WithParam).Result;

            funcParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public void TapAndCheck_F_AsyncLeft_returns_failure_and_does_not_execute_func()
        {
            Task<Result> input = Result.Failure(ErrorMessage).AsCompletedTask();

            Result output = input.TapAndCheck(GetResult_F).Result;

            AssertFailure(output);
        }

        [Fact]
        public void TapAndCheck_F_AsyncLeft_selects_new_result()
        {
            Task<Result> input = Result.Success().AsCompletedTask();

            Result output = input.TapAndCheck(GetResult_F).Result;

            AssertSuccess(output);
        }

        [Fact]
        public void TapAndCheck_T_F_AsyncLeft_returns_failure_and_does_not_execute_func()
        {
            Task<Result<T>> input = Result.Failure<T>(ErrorMessage).AsCompletedTask();

            Result<T> output = input.TapAndCheck(GetResult_F_WithParam).Result;

            AssertFailure(output);
        }

        [Fact]
        public void TapAndCheck_T_F_AsyncLeft_selects_new_result()
        {
            Task<Result<T>> input = Result.Success(T.Value).AsCompletedTask();

            Result<T> output = input.TapAndCheck(GetResult_F_WithParam).Result;

            funcParam.Should().Be(T.Value);
            AssertSuccess(output);
        }

        [Fact]
        public void TapAndCheck_T_F_E_AsyncLeft_returns_failure_and_does_not_execute_func()
        {
            Task<Result<T, E>> input = Result.Failure<T, E>(E.Value).AsCompletedTask();

            Result<T, E> output = input.TapAndCheck(GetResult_F_E_WithParam).Result;

            AssertFailure(output);
        }

        [Fact]
        public void TapAndCheck_T_F_E_AsyncLeft_selects_new_result()
        {
            Task<Result<T, E>> input = Result.Success<T, E>(T.Value).AsCompletedTask();

            Result<T, E> output = input.TapAndCheck(GetResult_F_E_WithParam).Result;

            funcParam.Should().Be(T.Value);
            AssertSuccess(output);
        }
    }
}
